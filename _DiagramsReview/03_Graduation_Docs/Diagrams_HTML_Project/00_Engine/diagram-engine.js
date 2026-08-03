/* =========================================================================
   EduMS Academic Diagram Engine  (pure HTML/SVG — no Mermaid, no PlantUML)
   -------------------------------------------------------------------------
   • Collision-free, math-corrected layout (grid packing + separation solver)
   • Save as SVG + Save as PNG on every diagram
   • Renderers: Chen ERD, DFD/Context, Use Case, UML Class, Sequence, Activity
   • RTL Arabic labels, LTR monospace for code identifiers
   ========================================================================= */
(function (global) {
'use strict';

const SVGNS = 'http://www.w3.org/2000/svg';

/* ============================ tiny SVG DSL ============================ */
function el(name, attrs, parent) {
  const n = document.createElementNS(SVGNS, name);
  if (attrs) for (const k in attrs) {
    if (attrs[k] === null || attrs[k] === undefined) continue;
    n.setAttribute(k, attrs[k]);
  }
  if (parent) parent.appendChild(n);
  return n;
}
function txt(parent, x, y, s, o) {
  o = o || {};
  const t = el('text', {
    x: x, y: y,
    'text-anchor': o.anchor || 'middle',
    'font-size': o.size || 12,
    'font-weight': o.weight || 400,
    fill: o.fill || '#0f172a',
    'font-family': o.mono ? "'Fira Code','Consolas',monospace" : "'Cairo','Tajawal',sans-serif",
    direction: o.mono ? 'ltr' : (o.dir || 'rtl'),
    opacity: o.opacity || null,
    transform: o.transform || null,
    'dominant-baseline': 'middle'
  }, parent);
  t.textContent = s;
  return t;
}
function measure(s, size, mono) {
  s = String(s == null ? '' : s);
  let w = 0;
  for (const ch of s) {
    const c = ch.codePointAt(0);
    if (c >= 0x0600 && c <= 0x06FF) w += size * 0.56;
    else if (mono) w += size * 0.60;
    else if (/[MWmw@]/.test(ch)) w += size * 0.82;
    else if (/[ilj.,'!|]/.test(ch)) w += size * 0.28;
    else if (/[A-Z]/.test(ch)) w += size * 0.62;
    else w += size * 0.52;
  }
  return w;
}
function clip(s, maxW, size, mono) {
  s = String(s == null ? '' : s);
  if (measure(s, size, mono) <= maxW) return s;
  let out = '';
  for (const ch of s) {
    if (measure(out + ch + '…', size, mono) > maxW) break;
    out += ch;
  }
  return out + '…';
}
function wrapText(s, maxW, size, mono) {
  s = String(s == null ? '' : s);
  const words = s.split(/\s+/), out = [];
  let cur = '';
  words.forEach(w => {
    const t = cur ? cur + ' ' + w : w;
    if (measure(t, size, mono) > maxW && cur) { out.push(cur); cur = w; }
    else cur = t;
  });
  if (cur) out.push(cur);
  return out.length ? out : [''];
}

/* ============================ markers / defs ============================ */
function defs(svg) {
  const d = el('defs', null, svg);
  const mk = (id, color, kind) => {
    const m = el('marker', {
      id: id, viewBox: '0 0 12 12', refX: kind === 'open' ? 11 : 10, refY: 6,
      markerWidth: 9, markerHeight: 9, orient: 'auto-start-reverse'
    }, d);
    if (kind === 'open')          el('path', { d: 'M1,1 L11,6 L1,11', fill: 'none', stroke: color, 'stroke-width': 1.7 }, m);
    else if (kind === 'hollow')   el('path', { d: 'M1,1 L11,6 L1,11 Z', fill: '#fff', stroke: color, 'stroke-width': 1.4 }, m);
    else if (kind === 'diamond')  el('path', { d: 'M1,6 L6,2 L11,6 L6,10 Z', fill: '#fff', stroke: color, 'stroke-width': 1.4 }, m);
    else if (kind === 'diamondF') el('path', { d: 'M1,6 L6,2 L11,6 L6,10 Z', fill: color, stroke: color, 'stroke-width': 1.4 }, m);
    else                          el('path', { d: 'M1,1 L11,6 L1,11 Z', fill: color, stroke: color }, m);
  };
  mk('arw', '#334155', 'solid');   mk('arwOpen', '#334155', 'open');
  mk('arwBlue', '#1d4ed8', 'solid');mk('arwGold', '#b45309', 'solid');
  mk('arwGreen', '#059669', 'solid');mk('arwRed', '#dc2626', 'solid');
  mk('inh', '#1e3a8a', 'hollow');  mk('agg', '#1e3a8a', 'diamond');
  mk('comp', '#1e3a8a', 'diamondF');
  const f = el('filter', { id: 'sh', x: '-25%', y: '-25%', width: '150%', height: '150%' }, d);
  el('feDropShadow', { dx: 0, dy: 1.6, stdDeviation: 1.9, 'flood-color': '#0f172a', 'flood-opacity': .17 }, f);
  return d;
}
function makeSvg(host, w, h, title) {
  if (typeof host === 'string') host = document.querySelector(host);
  host.innerHTML = '';
  const svg = el('svg', {
    xmlns: SVGNS, width: w, height: h, viewBox: `0 0 ${w} ${h}`, class: 'diagram'
  }, host);
  el('rect', { x: 0, y: 0, width: w, height: h, fill: '#ffffff' }, svg);
  defs(svg);
  if (title) {
    txt(svg, w / 2, 26, title, { size: 17, weight: 800, fill: '#1e3a8a' });
    el('line', { x1: 40, y1: 42, x2: w - 40, y2: 42, stroke: '#e2e8f0', 'stroke-width': 1.4 }, svg);
  }
  return svg;
}

/* ============================ EXPORT ============================ */
function serialize(svg) {
  const c = svg.cloneNode(true);
  c.setAttribute('xmlns', SVGNS);
  c.setAttribute('xmlns:xlink', 'http://www.w3.org/1999/xlink');
  const st = document.createElementNS(SVGNS, 'style');
  st.textContent =
    "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@400;600;700;800;900&family=Fira+Code:wght@400;500&display=swap');" +
    "text{font-family:'Cairo','Tajawal',sans-serif}";
  c.insertBefore(st, c.firstChild);
  return '<?xml version="1.0" encoding="UTF-8"?>\n' + new XMLSerializer().serializeToString(c);
}
function dl(blob, name) {
  const a = document.createElement('a');
  a.href = URL.createObjectURL(blob); a.download = name;
  document.body.appendChild(a); a.click(); a.remove();
  setTimeout(() => URL.revokeObjectURL(a.href), 4000);
}
function saveSVG(sel, name) {
  const svg = typeof sel === 'string' ? document.querySelector(sel) : sel;
  if (!svg) return alert('لا يوجد مخطط للتصدير');
  dl(new Blob([serialize(svg)], { type: 'image/svg+xml;charset=utf-8' }), (name || 'diagram') + '.svg');
}
function savePNG(sel, name, scale) {
  const svg = typeof sel === 'string' ? document.querySelector(sel) : sel;
  if (!svg) return alert('لا يوجد مخطط للتصدير');
  scale = scale || 2.5;
  const w = +svg.getAttribute('width'), h = +svg.getAttribute('height');
  const img = new Image();
  img.onload = function () {
    const cv = document.createElement('canvas');
    cv.width = Math.round(w * scale); cv.height = Math.round(h * scale);
    const ctx = cv.getContext('2d');
    ctx.fillStyle = '#fff'; ctx.fillRect(0, 0, cv.width, cv.height);
    ctx.drawImage(img, 0, 0, cv.width, cv.height);
    cv.toBlob(b => dl(b, (name || 'diagram') + '.png'), 'image/png');
  };
  img.onerror = () => alert('تعذّر إنشاء PNG — استخدم زر SVG');
  img.src = 'data:image/svg+xml;base64,' + btoa(unescape(encodeURIComponent(serialize(svg))));
}
function attachZoom(hostSel, svgSel, labelSel) {
  let z = 1;
  const apply = () => {
    const svg = document.querySelector(svgSel);
    if (!svg) return;
    svg.style.transform = 'scale(' + z + ')';
    svg.style.transformOrigin = 'top center';
    const lb = labelSel && document.querySelector(labelSel);
    if (lb) lb.textContent = Math.round(z * 100) + '%';
  };
  return {
    in: () => { z = Math.min(3.2, z + .15); apply(); },
    out: () => { z = Math.max(.25, z - .15); apply(); },
    reset: () => { z = 1; apply(); },
    fit: () => {
      const host = document.querySelector(hostSel), svg = document.querySelector(svgSel);
      if (!host || !svg) return;
      z = Math.min(1, (host.clientWidth - 26) / (+svg.getAttribute('width'))); apply();
    }
  };
}

/* ============================ LAYOUT ============================ */
function packRows(items, opts) {
  const o = Object.assign({ maxW: 1560, gapX: 34, gapY: 40, startX: 46, startY: 74 }, opts);
  let x = o.startX, y = o.startY, rowH = 0, maxRight = 0;
  items.forEach(it => {
    if (x > o.startX && x + it.w > o.maxW) { y += rowH + o.gapY; x = o.startX; rowH = 0; }
    it.x = x; it.y = y;
    x += it.w + o.gapX; rowH = Math.max(rowH, it.h);
    maxRight = Math.max(maxRight, it.x + it.w);
  });
  return { width: Math.max(maxRight + o.startX, 900), height: y + rowH + o.startY };
}
function ring(cx, cy, n, rx, ry, startDeg) {
  const out = []; const s = (startDeg == null ? -90 : startDeg) * Math.PI / 180;
  for (let i = 0; i < n; i++) {
    const a = s + (i * 2 * Math.PI / Math.max(n, 1));
    out.push({ x: cx + rx * Math.cos(a), y: cy + ry * Math.sin(a), a: a });
  }
  return out;
}
function separate(nodes, iters, pad) {
  iters = iters || 300; pad = pad == null ? 16 : pad;
  for (let k = 0; k < iters; k++) {
    let moved = false;
    for (let i = 0; i < nodes.length; i++) {
      for (let j = i + 1; j < nodes.length; j++) {
        const a = nodes[i], b = nodes[j];
        if (a.fixed && b.fixed) continue;
        const ox = Math.min(a.x + a.w, b.x + b.w) - Math.max(a.x, b.x) + pad;
        const oy = Math.min(a.y + a.h, b.y + b.h) - Math.max(a.y, b.y) + pad;
        if (ox > 0 && oy > 0) {
          moved = true;
          const acx = a.x + a.w / 2, acy = a.y + a.h / 2;
          const bcx = b.x + b.w / 2, bcy = b.y + b.h / 2;
          if (ox < oy) { const d = ox / 2 * (acx <= bcx ? -1 : 1);
            if (!a.fixed) a.x += d; if (!b.fixed) b.x -= d; }
          else { const d = oy / 2 * (acy <= bcy ? -1 : 1);
            if (!a.fixed) a.y += d; if (!b.fixed) b.y -= d; }
        }
      }
    }
    if (!moved) break;
  }
  let minX = Infinity, minY = Infinity;
  nodes.forEach(n => { minX = Math.min(minX, n.x); minY = Math.min(minY, n.y); });
  const dx = minX < 40 ? 40 - minX : 0, dy = minY < 70 ? 70 - minY : 0;
  if (dx || dy) nodes.forEach(n => { n.x += dx; n.y += dy; });
  let w = 0, h = 0;
  nodes.forEach(n => { w = Math.max(w, n.x + n.w); h = Math.max(h, n.y + n.h); });
  return { width: w + 46, height: h + 60 };
}
function edgePoint(r, tx, ty) {
  const cx = r.x + r.w / 2, cy = r.y + r.h / 2;
  const dx = tx - cx, dy = ty - cy;
  if (!dx && !dy) return { x: cx, y: cy };
  const sx = dx === 0 ? Infinity : (r.w / 2) / Math.abs(dx);
  const sy = dy === 0 ? Infinity : (r.h / 2) / Math.abs(dy);
  const s = Math.min(sx, sy);
  return { x: cx + dx * s, y: cy + dy * s };
}
function ellipsePoint(cx, cy, rx, ry, tx, ty) {
  const dx = tx - cx, dy = ty - cy, L = Math.hypot(dx / rx, dy / ry) || 1;
  return { x: cx + dx / L, y: cy + dy / L };
}
/* Bidirectional-safe connector: mirrored perpendicular offsets, never overlap */
function connect(svg, A, B, opt) {
  const o = Object.assign({ label: '', color: '#334155', marker: 'arw', dash: null,
    offset: 0, labelSize: 10.5, width: 1.7, labelBg: true, mono: false }, opt);
  const ac = { x: A.x + A.w / 2, y: A.y + A.h / 2 };
  const bc = { x: B.x + B.w / 2, y: B.y + B.h / 2 };
  const p1 = edgePoint(A, bc.x, bc.y), p2 = edgePoint(B, ac.x, ac.y);
  const vx = p2.x - p1.x, vy = p2.y - p1.y, L = Math.hypot(vx, vy) || 1;
  const nx = -vy / L, ny = vx / L, k = o.offset || 0;
  const a = { x: p1.x + nx * k, y: p1.y + ny * k };
  const b = { x: p2.x + nx * k, y: p2.y + ny * k };
  const mx = (a.x + b.x) / 2 + nx * (k ? k * 0.9 : 0);
  const my = (a.y + b.y) / 2 + ny * (k ? k * 0.9 : 0);
  el('path', {
    d: `M${a.x.toFixed(1)},${a.y.toFixed(1)} Q${mx.toFixed(1)},${my.toFixed(1)} ${b.x.toFixed(1)},${b.y.toFixed(1)}`,
    fill: 'none', stroke: o.color, 'stroke-width': o.width,
    'stroke-dasharray': o.dash, 'marker-end': `url(#${o.marker})`
  }, svg);
  if (o.label) {
    const lx = mx, ly = my - 7, w = measure(o.label, o.labelSize, o.mono) + 10;
    if (o.labelBg) el('rect', { x: lx - w / 2, y: ly - 9, width: w, height: 15, rx: 4,
      fill: '#ffffff', opacity: .93, stroke: '#e2e8f0', 'stroke-width': .8 }, svg);
    txt(svg, lx, ly, o.label, { size: o.labelSize, fill: '#475569', weight: 600, mono: o.mono });
  }
  return { a: a, b: b, mid: { x: mx, y: my } };
}
function offsetsFor(links) {
  const seen = {};
  links.forEach(l => {
    const key = [l.from, l.to].sort().join('~');
    seen[key] = (seen[key] || 0) + 1;
    const i = seen[key] - 1;
    l._off = i === 0 ? 0 : (i % 2 ? 1 : -1) * 18 * Math.ceil(i / 2);
  });
  return links;
}

/* ============================ shapes ============================ */
function processBox(svg, r, id, name, sub, color) {
  const c = color || '#1e3a8a';
  const g = el('g', { filter: 'url(#sh)' }, svg);
  el('rect', { x: r.x, y: r.y, width: r.w, height: r.h, rx: 7,
    fill: '#dbeafe', stroke: c, 'stroke-width': 2 }, g);
  el('path', { d: `M${r.x},${r.y + 25} L${r.x},${r.y + 7} Q${r.x},${r.y} ${r.x + 7},${r.y} ` +
    `L${r.x + r.w - 7},${r.y} Q${r.x + r.w},${r.y} ${r.x + r.w},${r.y + 7} L${r.x + r.w},${r.y + 25} Z`,
    fill: c }, g);
  txt(g, r.x + r.w / 2, r.y + 13, id, { size: 11, weight: 800, fill: '#fff', mono: true });
  const lines = wrapText(name, r.w - 16, 11.5);
  lines.slice(0, 3).forEach((ln, i) =>
    txt(g, r.x + r.w / 2, r.y + 42 + i * 15, ln, { size: 11.5, weight: 700, fill: '#0f172a' }));
  if (sub) txt(g, r.x + r.w / 2, r.y + r.h - 12, clip(sub, r.w - 14, 9.5, true),
    { size: 9.5, fill: '#475569', mono: true });
  return g;
}
function externalBox(svg, r, name, sub) {
  const g = el('g', { filter: 'url(#sh)' }, svg);
  el('rect', { x: r.x, y: r.y, width: r.w, height: r.h,
    fill: '#e2e8f0', stroke: '#475569', 'stroke-width': 2 }, g);
  el('line', { x1: r.x + 4, y1: r.y + 4, x2: r.x + r.w - 4, y2: r.y + 4, stroke: '#94a3b8', 'stroke-width': .9 }, g);
  const lines = wrapText(name, r.w - 14, 11.5);
  const y0 = r.y + r.h / 2 - (lines.length - 1) * 8 - (sub ? 6 : 0);
  lines.slice(0, 3).forEach((ln, i) =>
    txt(g, r.x + r.w / 2, y0 + i * 16, ln, { size: 11.5, weight: 700, fill: '#1e293b' }));
  if (sub) txt(g, r.x + r.w / 2, r.y + r.h - 11, clip(sub, r.w - 12, 9.5, true),
    { size: 9.5, fill: '#64748b', mono: true });
  return g;
}
function storeBox(svg, r, id, name, sub) {
  const g = el('g', { filter: 'url(#sh)' }, svg);
  el('rect', { x: r.x, y: r.y, width: r.w, height: r.h,
    fill: '#fef3c7', stroke: '#b45309', 'stroke-width': 2 }, g);
  el('rect', { x: r.x, y: r.y, width: 34, height: r.h, fill: '#b45309' }, g);
  txt(g, r.x + 17, r.y + r.h / 2, id, { size: 10.5, weight: 800, fill: '#fff', mono: true });
  const lines = wrapText(name, r.w - 48, 11);
  const y0 = r.y + r.h / 2 - (lines.length - 1) * 7 - (sub ? 5 : 0);
  lines.slice(0, 2).forEach((ln, i) =>
    txt(g, r.x + 40 + (r.w - 46) / 2, y0 + i * 14, ln, { size: 11, weight: 700, fill: '#78350f' }));
  if (sub) txt(g, r.x + 40 + (r.w - 46) / 2, r.y + r.h - 10, clip(sub, r.w - 52, 9, true),
    { size: 9, fill: '#92580a', mono: true });
  return g;
}

const DG = { el, txt, measure, clip, wrapText, makeSvg, defs, saveSVG, savePNG,
  attachZoom, serialize, packRows, ring, separate, edgePoint, ellipsePoint,
  connect, offsetsFor, processBox, externalBox, storeBox, renderers: {} };
global.DG = DG;
})(window);
