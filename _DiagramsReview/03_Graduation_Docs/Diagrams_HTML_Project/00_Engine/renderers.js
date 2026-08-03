/* =========================================================================
   EduMS Diagram Renderers — academic notation
   Requires diagram-engine.js (window.DG)
   ========================================================================= */
(function (DG) {
'use strict';
const { el, txt, measure, clip, wrapText, makeSvg, connect, offsetsFor,
        separate, edgePoint, ellipsePoint, ring, processBox, externalBox, storeBox } = DG;

/* =====================================================================
   1) CHEN ERD  — rectangles=entities, ovals=attributes, diamonds=relations
   ===================================================================== */
DG.renderers.chenERD = function (host, spec) {
  const ents = spec.entities || [];
  const rels = spec.relations || [];
  const ringMode = spec.layout === 'ring';
  const COLS = spec.cols || Math.min(3, Math.max(1, Math.round(Math.sqrt(ents.length))));
  const CW = spec.cellW || 620, CH = spec.cellH || 470;

  // ---- geometry ----
  let W, H, centers = [], AR = { rx: 0, ry: 0 };
  if (ringMode) {
    const n = Math.max(ents.length, 1);
    const rx = spec.ringRx || Math.max(340, n * 58);
    const ry = spec.ringRy || Math.max(270, rx * 0.62);
    W = spec.width || Math.round(rx * 2 + 620);
    H = spec.height || Math.round(ry * 2 + 620);
    const cx = W / 2, cy = H / 2 + 16;
    centers = ring(cx, cy, n, rx, ry, -90).map(p => ({ x: p.x, y: p.y, a: p.a }));
    AR = { rx: spec.attrRx || 152, ry: spec.attrRy || 112 };
  } else {
    W = spec.width || (COLS * CW + 90);
    H = spec.height || (Math.ceil(ents.length / COLS) * CH + 190);
    ents.forEach((e, i) => {
      const c = i % COLS, r = Math.floor(i / COLS);
      centers.push({ x: 60 + c * CW + CW / 2, y: 130 + r * CH + CH / 2 - 40, a: null });
    });
    AR = { rx: Math.min(CW / 2 - 60, 215), ry: Math.min(CH / 2 - 55, 165) };
  }
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  const boxes = {};
  ents.forEach((e, i) => {
    const cx = centers[i].x, cy = centers[i].y;
    const attrs = (e.attributes || []).slice(0, spec.maxAttrs || 12);

    // entity rectangle (double border if weak)
    const nameW = Math.max(150, measure(e.name, 13, true) + 44);
    const box = { x: cx - nameW / 2, y: cy - 25, w: nameW, h: 50 };
    boxes[e.name] = box;

    // attribute ovals: ring layout -> outward arc; grid layout -> full ring
    let pts;
    if (ringMode) {
      const base = centers[i].a, span = Math.PI * 0.92, n2 = Math.max(attrs.length, 1);
      pts = attrs.map((_, k) => {
        const ang = base - span / 2 + (n2 === 1 ? span / 2 : (k * span / (n2 - 1)));
        return { x: cx + AR.rx * Math.cos(ang), y: cy + AR.ry * Math.sin(ang) };
      });
    } else {
      pts = ring(cx, cy, attrs.length, AR.rx, AR.ry, -100);
    }
    attrs.forEach((a, k) => {
      const p = pts[k];
      const label = a.name;
      const aw = Math.max(70, measure(label, 9.5, true) / 2 + 30);
      const ah = 17;
      // link entity -> attribute
      const ep = edgePoint(box, p.x, p.y);
      const op = ellipsePoint(p.x, p.y, aw, ah, box.x + box.w / 2, box.y + box.h / 2);
      el('line', { x1: ep.x, y1: ep.y, x2: op.x, y2: op.y,
        stroke: '#94a3b8', 'stroke-width': 1.1 }, svg);
      const g = el('g', null, svg);
      el('ellipse', { cx: p.x, cy: p.y, rx: aw, ry: ah,
        fill: '#ffffff', stroke: a.pk ? '#1d4ed8' : (a.fk ? '#b45309' : '#64748b'),
        'stroke-width': a.pk ? 2 : 1.3 }, g);
      const t = txt(g, p.x, p.y, clip(label, aw * 2 - 12, 9.5, true),
        { size: 9.5, mono: true, weight: a.pk ? 700 : 400,
          fill: a.pk ? '#1d4ed8' : (a.fk ? '#92580a' : '#334155') });
      if (a.pk) t.setAttribute('text-decoration', 'underline');
    });

    // draw entity on top
    const g = el('g', { filter: 'url(#sh)' }, svg);
    if (e.weak) el('rect', { x: box.x - 4, y: box.y - 4, width: box.w + 8, height: box.h + 8,
      rx: 4, fill: 'none', stroke: '#1d4ed8', 'stroke-width': 1.4 }, g);
    el('rect', { x: box.x, y: box.y, width: box.w, height: box.h, rx: 4,
      fill: '#dbeafe', stroke: '#1d4ed8', 'stroke-width': 2.2 }, g);
    txt(g, cx, cy - 8, clip(e.name, box.w - 14, 12.5, true),
      { size: 12.5, weight: 800, mono: true, fill: '#1e3a8a' });
    if (e.ar) txt(g, cx, cy + 10, clip(e.ar, box.w - 12, 9.5), { size: 9.5, fill: '#475569' });
    if (e.table) txt(g, cx, box.y + box.h + 13, clip(e.table, box.w + 60, 9, true),
      { size: 9, mono: true, fill: '#94a3b8' });
  });

  // relationship diamonds between entity pairs
  offsetsFor(rels.map(r => ({ from: r.from, to: r.to, ...r })));
  rels.forEach((r, i) => {
    const A = boxes[r.from], B = boxes[r.to];
    if (!A || !B) return;
    const mx = (A.x + A.w / 2 + B.x + B.w / 2) / 2;
    const my = (A.y + A.h / 2 + B.y + B.h / 2) / 2 + (r._off || 0);
    const lbl = r.name || 'has';
    const dw = Math.max(96, measure(lbl, 9.5, true) + 40), dh = 40;
    // lines entity -> diamond
    const dm = { x: mx - dw / 2, y: my - dh / 2, w: dw, h: dh };
    const a1 = edgePoint(A, mx, my), d1 = edgePoint(dm, A.x + A.w / 2, A.y + A.h / 2);
    const a2 = edgePoint(B, mx, my), d2 = edgePoint(dm, B.x + B.w / 2, B.y + B.h / 2);
    el('line', { x1: a1.x, y1: a1.y, x2: d1.x, y2: d1.y, stroke: '#b45309', 'stroke-width': 1.6 }, svg);
    el('line', { x1: a2.x, y1: a2.y, x2: d2.x, y2: d2.y, stroke: '#b45309', 'stroke-width': 1.6 }, svg);
    // cardinality labels (1 : M)
    txt(svg, (a1.x + d1.x) / 2, (a1.y + d1.y) / 2 - 9, r.cardFrom || '1',
      { size: 11, weight: 800, fill: '#b45309', mono: true });
    txt(svg, (a2.x + d2.x) / 2, (a2.y + d2.y) / 2 - 9, r.cardTo || 'M',
      { size: 11, weight: 800, fill: '#b45309', mono: true });
    // diamond
    const g = el('g', { filter: 'url(#sh)' }, svg);
    el('path', { d: `M${mx - dw / 2},${my} L${mx},${my - dh / 2} L${mx + dw / 2},${my} L${mx},${my + dh / 2} Z`,
      fill: '#fde68a', stroke: '#b45309', 'stroke-width': 1.8 }, g);
    txt(g, mx, my, clip(lbl, dw - 22, 9.5, true), { size: 9.5, weight: 700, mono: true, fill: '#78350f' });
  });
  return svg;
};

/* =====================================================================
   2) CONTEXT / DFD  — academic rectangles (dark header + light body)
   ===================================================================== */
DG.renderers.dfd = function (host, spec) {
  const procs = spec.processes || [];
  const exts = spec.externals || [];
  const stores = spec.stores || [];
  const flows = spec.flows || [];
  const W = spec.width || 1580;
  const H = spec.height || 980;
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  const nodes = {};
  const cx = W / 2, cy = H / 2 + 20;

  // processes: center ring (or explicit grid)
  const PW = spec.procW || 210, PH = spec.procH || 96;
  if (procs.length === 1) {
    const r = { x: cx - PW * 0.7, y: cy - PH * 0.75, w: PW * 1.4, h: PH * 1.5 };
    nodes[procs[0].id] = r;
  } else {
    const rx = Math.min(W * 0.24, 330), ry = Math.min(H * 0.23, 210);
    const pts = ring(cx, cy, procs.length, rx, ry, -90);
    procs.forEach((p, i) => {
      nodes[p.id] = { x: pts[i].x - PW / 2, y: pts[i].y - PH / 2, w: PW, h: PH };
    });
  }
  // externals: outer ring
  const EW = spec.extW || 176, EH = spec.extH || 66;
  const erx = W * 0.43, ery = H * 0.40;
  const epts = ring(cx, cy, exts.length, erx, ery, -90);
  exts.forEach((e, i) => {
    nodes[e.id] = { x: Math.max(20, Math.min(W - EW - 20, epts[i].x - EW / 2)),
                    y: Math.max(70, Math.min(H - EH - 20, epts[i].y - EH / 2)), w: EW, h: EH };
  });
  // stores: bottom band
  const SW = spec.storeW || 200, SH = spec.storeH || 56;
  const perRow = Math.max(1, Math.floor((W - 80) / (SW + 22)));
  stores.forEach((s, i) => {
    const r = Math.floor(i / perRow), c = i % perRow;
    const rowCount = Math.min(perRow, stores.length - r * perRow);
    const totalW = rowCount * SW + (rowCount - 1) * 22;
    nodes[s.id] = { x: (W - totalW) / 2 + c * (SW + 22),
                    y: H - 96 - r * (SH + 16), w: SW, h: SH };
  });

  // resolve collisions between all node types
  const arr = Object.keys(nodes).map(k => Object.assign({ key: k }, nodes[k]));
  separate(arr, 220, 22);
  arr.forEach(n => { nodes[n.key].x = n.x; nodes[n.key].y = n.y; });

  // flows first (behind shapes)
  offsetsFor(flows);
  flows.forEach(f => {
    const A = nodes[f.from], B = nodes[f.to];
    if (!A || !B) return;
    connect(svg, A, B, {
      label: f.label || '', color: f.color || '#334155',
      marker: f.marker || 'arw', dash: f.dash || null,
      offset: f._off || 0, labelSize: 9.8, width: 1.6, mono: f.mono
    });
  });

  // shapes on top
  exts.forEach(e => externalBox(svg, nodes[e.id], e.name, e.sub));
  stores.forEach(s => storeBox(svg, nodes[s.id], s.id, s.name, s.sub));
  procs.forEach(p => processBox(svg, nodes[p.id], p.id, p.name, p.sub, p.color));
  return svg;
};

/* =====================================================================
   3) USE CASE — stick figures OUTSIDE the system boundary box
   ===================================================================== */
DG.renderers.useCase = function (host, spec) {
  const actors = spec.actors || [];
  const ucs = spec.useCases || [];
  const links = spec.links || [];
  const W = spec.width || 1520;
  const perCol = Math.ceil(ucs.length / (spec.ucCols || 2));
  const H = spec.height || Math.max(760, 190 + perCol * 76);
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  // split actors: primary on right (RTL), secondary/system on left
  const right = actors.filter(a => !a.secondary);
  const left = actors.filter(a => a.secondary);
  const BX = 300, BW = W - 600, BY = 92, BH = H - 150;

  // system boundary
  el('rect', { x: BX, y: BY, width: BW, height: BH, rx: 12,
    fill: '#f8fafc', stroke: '#1e3a8a', 'stroke-width': 2.4, 'stroke-dasharray': '0' }, svg);
  el('rect', { x: BX, y: BY, width: BW, height: 34, rx: 12, fill: '#1e3a8a' }, svg);
  el('rect', { x: BX, y: BY + 22, width: BW, height: 12, fill: '#1e3a8a' }, svg);
  txt(svg, BX + BW / 2, BY + 17, spec.boundary || 'EduMS System',
    { size: 13, weight: 800, fill: '#fff' });

  // use case ovals inside boundary
  const cols = spec.ucCols || 2;
  const nodes = {};
  const uw = Math.min(268, (BW - 70) / cols - 26), uh = 34;
  ucs.forEach((u, i) => {
    const c = i % cols, r = Math.floor(i / cols);
    const colW = (BW - 60) / cols;
    const x = BX + 30 + c * colW + colW / 2;
    const y = BY + 78 + r * 72;
    nodes[u.id] = { x: x - uw / 2, y: y - uh / 2, w: uw, h: uh, cx: x, cy: y, rx: uw / 2, ry: uh / 2 };
  });

  function drawActor(x, y, name, sub, color) {
    const g = el('g', null, svg);
    const c = color || '#0f172a';
    el('circle', { cx: x, cy: y - 26, r: 11, fill: '#fff', stroke: c, 'stroke-width': 2 }, g);
    el('line', { x1: x, y1: y - 15, x2: x, y2: y + 10, stroke: c, 'stroke-width': 2 }, g);
    el('line', { x1: x - 15, y1: y - 6, x2: x + 15, y2: y - 6, stroke: c, 'stroke-width': 2 }, g);
    el('line', { x1: x, y1: y + 10, x2: x - 12, y2: y + 30, stroke: c, 'stroke-width': 2 }, g);
    el('line', { x1: x, y1: y + 10, x2: x + 12, y2: y + 30, stroke: c, 'stroke-width': 2 }, g);
    const lines = wrapText(name, 150, 11);
    lines.slice(0, 2).forEach((ln, i) =>
      txt(g, x, y + 46 + i * 14, ln, { size: 11, weight: 700, fill: '#1e293b' }));
    if (sub) txt(g, x, y + 46 + lines.length * 14, clip(sub, 160, 9, true),
      { size: 9, mono: true, fill: '#94a3b8' });
    return { x: x - 20, y: y - 38, w: 40, h: 76 };
  }

  const actorNodes = {};
  const rStep = Math.max(120, (BH - 60) / Math.max(right.length, 1));
  right.forEach((a, i) => {
    actorNodes[a.id] = drawActor(BX + BW + 150, BY + 60 + i * rStep + 20, a.name, a.sub, a.color);
  });
  const lStep = Math.max(120, (BH - 60) / Math.max(left.length, 1));
  left.forEach((a, i) => {
    actorNodes[a.id] = drawActor(BX - 150, BY + 60 + i * lStep + 20, a.name, a.sub, a.color || '#7c3aed');
  });

  // association lines actor -> use case
  offsetsFor(links);
  links.forEach(l => {
    const A = actorNodes[l.actor], U = nodes[l.uc];
    if (!A || !U) return;
    const ap = edgePoint(A, U.cx, U.cy);
    const up = ellipsePoint(U.cx, U.cy, U.rx, U.ry, A.x + A.w / 2, A.y + A.h / 2);
    el('line', { x1: ap.x, y1: ap.y, x2: up.x, y2: up.y,
      stroke: l.color || '#64748b', 'stroke-width': 1.3,
      'stroke-dasharray': l.dash || null }, svg);
  });

  // include/extend relations
  (spec.relations || []).forEach(r => {
    const A = nodes[r.from], B = nodes[r.to];
    if (!A || !B) return;
    const a = ellipsePoint(A.cx, A.cy, A.rx, A.ry, B.cx, B.cy);
    const b = ellipsePoint(B.cx, B.cy, B.rx, B.ry, A.cx, A.cy);
    el('line', { x1: a.x, y1: a.y, x2: b.x, y2: b.y, stroke: '#7c3aed',
      'stroke-width': 1.3, 'stroke-dasharray': '6,4', 'marker-end': 'url(#arwOpen)' }, svg);
    txt(svg, (a.x + b.x) / 2, (a.y + b.y) / 2 - 8, `«${r.kind || 'include'}»`,
      { size: 9, mono: true, fill: '#7c3aed', weight: 700 });
  });

  // ovals on top
  ucs.forEach(u => {
    const n = nodes[u.id];
    const g = el('g', { filter: 'url(#sh)' }, svg);
    el('ellipse', { cx: n.cx, cy: n.cy, rx: n.rx, ry: n.ry,
      fill: '#dbeafe', stroke: '#1d4ed8', 'stroke-width': 1.8 }, g);
    txt(g, n.cx, n.cy - 5, clip(u.name, uw - 20, 10.5), { size: 10.5, weight: 700, fill: '#1e3a8a' });
    if (u.sub) txt(g, n.cx, n.cy + 9, clip(u.sub, uw - 16, 8.5, true),
      { size: 8.5, mono: true, fill: '#64748b' });
  });
  return svg;
};

/* =====================================================================
   4) UML CLASS — 3 compartments (name / attributes / operations)
   ===================================================================== */
DG.renderers.umlClass = function (host, spec) {
  const cls = spec.classes || [];
  const rels = spec.relations || [];
  const maxA = spec.maxAttrs || 12, maxM = spec.maxMethods || 8;

  const boxes = cls.map(c => {
    const attrs = (c.attributes || []).slice(0, maxA);
    const meths = (c.methods || []).slice(0, maxM);
    let w = measure(c.name, 13.5, true) + 46;
    attrs.forEach(a => w = Math.max(w, measure(`${a.vis || '+'} ${a.name}: ${a.type}`, 10, true) + 30));
    meths.forEach(m => w = Math.max(w, measure(`${m.vis || '+'} ${m.name}(): ${m.ret}`, 10, true) + 30));
    w = Math.min(Math.max(w, 208), spec.maxBoxW || 330);
    const h = 42 + (c.ar ? 14 : 0) + attrs.length * 16 + 10 + meths.length * 16 + 12
              + (attrs.length > (c.attributes || []).length ? 0 : 0)
              + ((c.attributes || []).length > maxA ? 14 : 0)
              + ((c.methods || []).length > maxM ? 14 : 0);
    return { key: c.name, name: c.name, ar: c.ar, stereo: c.stereo, color: c.color,
             attrs, meths, more_a: Math.max(0, (c.attributes || []).length - maxA),
             more_m: Math.max(0, (c.methods || []).length - maxM),
             w: w, h: Math.max(h, 78), x: 0, y: 0 };
  });

  const pack = DG.packRows(boxes, { maxW: spec.width ? spec.width - 60 : 1560, gapX: 46, gapY: 52 });
  const W = spec.width || pack.width, H = spec.height || pack.height + 30;
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  const map = {}; boxes.forEach(b => map[b.key] = b);

  // relations behind boxes
  offsetsFor(rels);
  rels.forEach(r => {
    const A = map[r.from], B = map[r.to];
    if (!A || !B) return;
    const marker = r.kind === 'inheritance' ? 'inh'
                 : r.kind === 'composition' ? 'comp'
                 : r.kind === 'aggregation' ? 'agg' : 'arwOpen';
    const c = connect(svg, A, B, {
      label: r.label || '', color: r.kind === 'dependency' ? '#94a3b8' : '#1e3a8a',
      marker: marker, dash: r.kind === 'dependency' ? '6,4' : null,
      offset: r._off || 0, labelSize: 9.5, width: 1.4, mono: true
    });
    if (r.multFrom) txt(svg, c.a.x + (c.mid.x - c.a.x) * .18, c.a.y + (c.mid.y - c.a.y) * .18 - 8,
      r.multFrom, { size: 9.5, mono: true, fill: '#475569', weight: 700 });
    if (r.multTo) txt(svg, c.b.x + (c.mid.x - c.b.x) * .18, c.b.y + (c.mid.y - c.b.y) * .18 - 8,
      r.multTo, { size: 9.5, mono: true, fill: '#475569', weight: 700 });
  });

  boxes.forEach(b => {
    const col = b.color || '#1e3a8a';
    const g = el('g', { filter: 'url(#sh)' }, svg);
    el('rect', { x: b.x, y: b.y, width: b.w, height: b.h, rx: 5,
      fill: '#ffffff', stroke: col, 'stroke-width': 1.9 }, g);
    const hh = b.ar ? 40 : 28;
    el('path', { d: `M${b.x},${b.y + hh} L${b.x},${b.y + 5} Q${b.x},${b.y} ${b.x + 5},${b.y} ` +
      `L${b.x + b.w - 5},${b.y} Q${b.x + b.w},${b.y} ${b.x + b.w},${b.y + 5} L${b.x + b.w},${b.y + hh} Z`,
      fill: col }, g);
    let y = b.y + 15;
    if (b.stereo) { txt(g, b.x + b.w / 2, y - 4, `«${b.stereo}»`, { size: 8.5, mono: true, fill: '#dbeafe' }); y += 10; }
    txt(g, b.x + b.w / 2, y, clip(b.name, b.w - 16, 12.5, true),
      { size: 12.5, weight: 800, fill: '#fff', mono: true });
    if (b.ar) txt(g, b.x + b.w / 2, y + 15, clip(b.ar, b.w - 12, 9), { size: 9, fill: '#c7d2fe' });

    let cy = b.y + hh + 13;
    b.attrs.forEach(a => {
      const s = `${a.vis || '+'} ${a.name}: ${a.type}`;
      txt(g, b.x + b.w - 9, cy, clip(s, b.w - 18, 10, true),
        { size: 10, mono: true, anchor: 'end',
          fill: a.pk ? '#1d4ed8' : (a.fk ? '#b45309' : '#334155'),
          weight: (a.pk || a.fk) ? 700 : 400 });
      cy += 16;
    });
    if (b.more_a) { txt(g, b.x + b.w - 9, cy, `… +${b.more_a} attributes`,
      { size: 9, mono: true, anchor: 'end', fill: '#94a3b8' }); cy += 14; }

    if (b.meths.length || b.more_m) {
      el('line', { x1: b.x, y1: cy - 6, x2: b.x + b.w, y2: cy - 6, stroke: '#cbd5e1', 'stroke-width': 1.2 }, g);
      cy += 8;
      b.meths.forEach(m => {
        const args = (m.args || []).slice(0, 2).join(', ');
        const s = `${m.vis || '+'} ${m.name}(${args}): ${m.ret || 'void'}`;
        txt(g, b.x + b.w - 9, cy, clip(s, b.w - 18, 10, true),
          { size: 10, mono: true, anchor: 'end', fill: '#0f766e' });
        cy += 16;
      });
      if (b.more_m) txt(g, b.x + b.w - 9, cy, `… +${b.more_m} operations`,
        { size: 9, mono: true, anchor: 'end', fill: '#94a3b8' });
    }
  });
  return svg;
};

/* =====================================================================
   5) SEQUENCE — lifelines, activation bars, numbered messages
   ===================================================================== */
DG.renderers.sequence = function (host, spec) {
  const parts = spec.participants || [];
  const msgs = spec.messages || [];
  const LW = spec.laneW || Math.max(190, Math.min(240, 1500 / Math.max(parts.length, 1)));
  const W = spec.width || (parts.length * LW + 110);
  const top = 108, step = spec.step || 46;
  const H = spec.height || (top + msgs.length * step + 130);
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  const X = {};
  parts.forEach((p, i) => {
    const x = 60 + i * LW + LW / 2;
    X[p.id] = x;
    const bw = Math.min(LW - 22, Math.max(120, measure(p.name, 11, true) + 30));
    const g = el('g', { filter: 'url(#sh)' }, svg);
    const col = p.color || (p.kind === 'actor' ? '#0f172a' :
                p.kind === 'db' ? '#b45309' : p.kind === 'ui' ? '#7c3aed' : '#1e3a8a');
    el('rect', { x: x - bw / 2, y: top - 44, width: bw, height: 38, rx: 6,
      fill: col, stroke: col, 'stroke-width': 1.6 }, g);
    txt(g, x, top - 31, clip(p.name, bw - 12, 10.5, true),
      { size: 10.5, weight: 800, fill: '#fff', mono: true });
    if (p.sub) txt(g, x, top - 17, clip(p.sub, bw - 10, 8.5), { size: 8.5, fill: '#dbeafe' });
    // lifeline
    el('line', { x1: x, y1: top - 4, x2: x, y2: H - 60,
      stroke: '#94a3b8', 'stroke-width': 1.3, 'stroke-dasharray': '6,5' }, svg);
    if (p.stereo) txt(svg, x, H - 44, `«${p.stereo}»`, { size: 8.5, mono: true, fill: '#94a3b8' });
  });

  // activation bars
  (spec.activations || []).forEach(a => {
    const x = X[a.of]; if (x == null) return;
    el('rect', { x: x - 6, y: top + (a.from - 1) * step - 8, width: 12,
      height: (a.to - a.from + 1) * step, fill: '#bfdbfe', stroke: '#1d4ed8', 'stroke-width': 1.1, rx: 2 }, svg);
  });

  msgs.forEach((m, i) => {
    const y = top + i * step;
    const x1 = X[m.from], x2 = X[m.to];
    if (x1 == null || x2 == null) return;
    const isRet = m.kind === 'return';
    const col = isRet ? '#059669' : (m.kind === 'async' ? '#7c3aed' : (m.kind === 'error' ? '#dc2626' : '#1e3a8a'));

    if (x1 === x2) { // self-call
      const r = 26;
      el('path', { d: `M${x1},${y} L${x1 + r},${y} L${x1 + r},${y + 20} L${x1 + 4},${y + 20}`,
        fill: 'none', stroke: col, 'stroke-width': 1.6, 'marker-end': 'url(#arw)' }, svg);
      txt(svg, x1 + r + 8, y + 10, clip(`${i + 1}. ${m.label}`, 260, 9.5, true),
        { size: 9.5, mono: true, anchor: 'start', fill: '#334155' });
    } else {
      el('line', { x1: x1, y1: y, x2: x2 + (x2 > x1 ? -7 : 7), y2: y,
        stroke: col, 'stroke-width': isRet ? 1.3 : 1.7,
        'stroke-dasharray': isRet ? '6,4' : null, 'marker-end': 'url(#arw)' }, svg);
      const mx = (x1 + x2) / 2;
      const label = `${i + 1}. ${m.label}`;
      const lw = measure(label, 9.5, true) + 12;
      el('rect', { x: mx - lw / 2, y: y - 17, width: lw, height: 15, rx: 3,
        fill: '#fff', opacity: .95, stroke: '#e2e8f0', 'stroke-width': .8 }, svg);
      txt(svg, mx, y - 10, label, { size: 9.5, mono: true, fill: isRet ? '#059669' : '#334155', weight: 600 });
    }
    if (m.note) txt(svg, W - 30, y, clip(m.note, 240, 8.5), { size: 8.5, anchor: 'end', fill: '#94a3b8' });
  });
  return svg;
};

/* =====================================================================
   6) ACTIVITY — start/end, actions, decisions, fork/join, swimlanes
   ===================================================================== */
DG.renderers.activity = function (host, spec) {
  const nodes = spec.nodes || [];
  const edges = spec.edges || [];
  const lanes = spec.lanes || [];
  const W = spec.width || 1280;
  const laneW = lanes.length ? (W - 80) / lanes.length : 0;
  let maxY = 0;
  nodes.forEach(n => maxY = Math.max(maxY, (n.row || 0)));
  const rowH = spec.rowH || 96;
  const H = spec.height || (150 + (maxY + 1) * rowH + 60);
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  // swimlanes
  if (lanes.length) {
    lanes.forEach((l, i) => {
      const x = 40 + i * laneW;
      el('rect', { x: x, y: 84, width: laneW, height: H - 130,
        fill: i % 2 ? '#f8fafc' : '#ffffff', stroke: '#cbd5e1', 'stroke-width': 1.2 }, svg);
      el('rect', { x: x, y: 84, width: laneW, height: 30, fill: l.color || '#1e3a8a' }, svg);
      txt(svg, x + laneW / 2, 99, l.name, { size: 11.5, weight: 800, fill: '#fff' });
    });
  }

  const pos = {};
  nodes.forEach(n => {
    const laneIdx = lanes.length ? Math.max(0, lanes.findIndex(l => l.id === n.lane)) : 0;
    const cx = lanes.length ? 40 + laneIdx * laneW + laneW / 2 : (n.col != null ? 120 + n.col * 240 : W / 2);
    const cy = 150 + (n.row || 0) * rowH;
    pos[n.id] = { cx, cy };
  });

  // edges first
  edges.forEach(e => {
    const A = pos[e.from], B = pos[e.to];
    if (!A || !B) return;
    const path = (A.cx === B.cx)
      ? `M${A.cx},${A.cy + 22} L${B.cx},${B.cy - 24}`
      : `M${A.cx},${A.cy + 22} L${A.cx},${A.cy + 46} L${B.cx},${A.cy + 46} L${B.cx},${B.cy - 24}`;
    el('path', { d: path, fill: 'none', stroke: e.color || '#334155',
      'stroke-width': 1.6, 'marker-end': 'url(#arw)', 'stroke-dasharray': e.dash || null }, svg);
    if (e.label) {
      const mx = (A.cx + B.cx) / 2, my = A.cy + 40;
      const lw = measure(e.label, 9.5) + 12;
      el('rect', { x: mx - lw / 2, y: my - 9, width: lw, height: 15, rx: 3,
        fill: '#fff', stroke: '#e2e8f0', 'stroke-width': .8 }, svg);
      txt(svg, mx, my - 1, e.label, { size: 9.5, fill: '#475569', weight: 700 });
    }
  });

  nodes.forEach(n => {
    const p = pos[n.id]; const g = el('g', { filter: 'url(#sh)' }, svg);
    if (n.kind === 'start') {
      el('circle', { cx: p.cx, cy: p.cy, r: 15, fill: '#0f172a' }, g);
    } else if (n.kind === 'end') {
      el('circle', { cx: p.cx, cy: p.cy, r: 16, fill: '#fff', stroke: '#0f172a', 'stroke-width': 2.4 }, g);
      el('circle', { cx: p.cx, cy: p.cy, r: 10, fill: '#0f172a' }, g);
    } else if (n.kind === 'decision') {
      const w = Math.max(120, measure(n.label, 10) + 46), h = 52;
      el('path', { d: `M${p.cx - w / 2},${p.cy} L${p.cx},${p.cy - h / 2} L${p.cx + w / 2},${p.cy} L${p.cx},${p.cy + h / 2} Z`,
        fill: '#fde68a', stroke: '#b45309', 'stroke-width': 1.9 }, g);
      wrapText(n.label, w - 26, 9.5).slice(0, 2).forEach((ln, i) =>
        txt(g, p.cx, p.cy - 5 + i * 12, ln, { size: 9.5, weight: 700, fill: '#78350f' }));
    } else if (n.kind === 'fork' || n.kind === 'join') {
      el('rect', { x: p.cx - 90, y: p.cy - 5, width: 180, height: 9, rx: 2, fill: '#0f172a' }, g);
      txt(g, p.cx, p.cy - 18, n.label || (n.kind === 'fork' ? 'Fork' : 'Join'),
        { size: 9.5, mono: true, fill: '#475569', weight: 700 });
    } else {
      const w = Math.max(160, Math.min(280, measure(n.label, 10.5) + 40)), h = 46;
      el('rect', { x: p.cx - w / 2, y: p.cy - h / 2, width: w, height: h, rx: 12,
        fill: n.fill || '#dbeafe', stroke: n.stroke || '#1d4ed8', 'stroke-width': 1.8 }, g);
      const lines = wrapText(n.label, w - 20, 10.5);
      lines.slice(0, 2).forEach((ln, i) =>
        txt(g, p.cx, p.cy - (lines.length > 1 ? 6 : 0) + i * 13 - (n.sub ? 4 : 0), ln,
          { size: 10.5, weight: 700, fill: '#0f172a' }));
      if (n.sub) txt(g, p.cx, p.cy + h / 2 - 9, clip(n.sub, w - 14, 8.5, true),
        { size: 8.5, mono: true, fill: '#64748b' });
    }
  });
  return svg;
};

/* =====================================================================
   7) COMPONENT / DEPLOYMENT (layered boxes)
   ===================================================================== */
DG.renderers.layered = function (host, spec) {
  const layers = spec.layers || [];
  const links = spec.links || [];
  const W = spec.width || 1440;
  const padTop = 92, layerGap = 26;
  let y = padTop, H = 0;
  const geo = [];
  layers.forEach(L => {
    const items = L.items || [];
    const perRow = L.perRow || Math.min(items.length, 5);
    const rows = Math.ceil(items.length / perRow);
    const bh = 66, gap = 18;
    const inner = rows * bh + (rows - 1) * gap + 52;
    geo.push({ y: y, h: inner, rows, perRow, bh, gap });
    y += inner + layerGap;
  });
  H = spec.height || y + 40;
  const svg = makeSvg(host, W, H, spec.title);
  if (spec.subtitle) txt(svg, W / 2, 58, spec.subtitle, { size: 12, fill: '#64748b' });

  const nodes = {};
  layers.forEach((L, li) => {
    const g0 = geo[li];
    el('rect', { x: 40, y: g0.y, width: W - 80, height: g0.h, rx: 12,
      fill: L.bg || '#f8fafc', stroke: L.color || '#cbd5e1', 'stroke-width': 1.6,
      'stroke-dasharray': L.dashed ? '8,5' : null }, svg);
    el('rect', { x: 40, y: g0.y, width: 190, height: 26, rx: 12, fill: L.color || '#475569' }, svg);
    el('rect', { x: 40, y: g0.y + 14, width: 190, height: 12, fill: L.color || '#475569' }, svg);
    txt(svg, 135, g0.y + 13, L.name, { size: 11.5, weight: 800, fill: '#fff' });

    const items = L.items || [];
    items.forEach((it, i) => {
      const r = Math.floor(i / g0.perRow), c = i % g0.perRow;
      const rowCount = Math.min(g0.perRow, items.length - r * g0.perRow);
      const bw = Math.min(240, (W - 140) / g0.perRow - 16);
      const totalW = rowCount * bw + (rowCount - 1) * g0.gap;
      const x = (W - totalW) / 2 + c * (bw + g0.gap);
      const yy = g0.y + 38 + r * (g0.bh + g0.gap);
      nodes[it.id] = { x, y: yy, w: bw, h: g0.bh };
      const gg = el('g', { filter: 'url(#sh)' }, svg);
      el('rect', { x, y: yy, width: bw, height: g0.bh, rx: 7,
        fill: '#fff', stroke: it.color || L.color || '#1e3a8a', 'stroke-width': 1.8 }, gg);
      el('rect', { x: x, y: yy, width: 5, height: g0.bh, rx: 2, fill: it.color || L.color || '#1e3a8a' }, gg);
      if (it.stereo) txt(gg, x + bw / 2, yy + 13, `«${it.stereo}»`, { size: 8.5, mono: true, fill: '#94a3b8' });
      const lines = wrapText(it.name, bw - 20, 10.5);
      lines.slice(0, 2).forEach((ln, k) =>
        txt(gg, x + bw / 2, yy + (it.stereo ? 29 : 24) + k * 13, ln, { size: 10.5, weight: 700, fill: '#1e293b' }));
      if (it.sub) txt(gg, x + bw / 2, yy + g0.bh - 11, clip(it.sub, bw - 14, 8.5, true),
        { size: 8.5, mono: true, fill: '#64748b' });
    });
  });

  offsetsFor(links);
  links.forEach(l => {
    const A = nodes[l.from], B = nodes[l.to];
    if (!A || !B) return;
    connect(svg, A, B, { label: l.label || '', color: l.color || '#64748b',
      marker: 'arwOpen', dash: l.dash || '5,4', offset: l._off || 0, labelSize: 9, mono: true, width: 1.3 });
  });
  return svg;
};

})(window.DG);
