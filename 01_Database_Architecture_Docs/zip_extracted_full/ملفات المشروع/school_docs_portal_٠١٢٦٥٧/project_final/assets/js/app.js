/* ================================================================
   School System Documentation Portal - Single-app JS
   Renders Home, Module, Operation pages from data/diagrams.json
   ================================================================ */

const SECTION_META = {
  section1: { icon: '🏫', name: 'إدارة المدرسة والمكتب', desc: 'تسجيل المدارس واعتمادها وإدارة هيكلها التنظيمي', range: '1-65' },
  section2: { icon: '🎓', name: 'إدارة الطلاب', desc: 'تسجيل الطلاب وقيدهم ومتابعة شؤونهم الأكاديمية', range: '66-150' },
  section3: { icon: '👥', name: 'إدارة الموظفين', desc: 'توظيف وإدارة المعلمين والإداريين والصلاحيات الوظيفية', range: '151-185' },
  section4: { icon: '📦', name: 'إدارة الأصول', desc: 'تسجيل الأصول وجردها وصيانتها وحركتها بين الأقسام', range: '186-275' },
  section5: { icon: '💰', name: 'الإدارة المالية', desc: 'الفواتير والمدفوعات والخصومات والتقارير المالية', range: '276-305' },
  section6: { icon: '🔐', name: 'الصلاحيات والأمان', desc: 'إدارة المستخدمين والأدوار والصلاحيات وسجل التدقيق', range: '306-330' },
  section7: { icon: '🚨', name: 'الطوارئ والسلامة', desc: 'خطط الطوارئ والإخلاء والإبلاغ عن الحوادث', range: '331-340' },
  section8: { icon: '📊', name: 'الإحصاء والتقارير', desc: 'الإحصائيات المدرسية والتقارير التحليلية ولوحات المؤشرات', range: '341-363' },
};

const SECTION_ORDER = ['section1','section2','section3','section4','section5','section6','section7','section8'];

// ----- State -----
let DATA = null;           // loaded JSON: { section1: {section_id, section_name, range, operations:[...] } }
let FLAT_OPS = [];         // [{op_id, title, section_id, ...}]
const isHome = () => location.hash === '' || location.hash === '#';
const parseHash = () => {
  // Hash formats:  #/section/section2  |  #/op/section2/74  |  #/report
  const h = location.hash.replace(/^#\/?/,'').split('/');
  if (h[0] === 'section' && h[1]) return { view: 'section', sid: h[1] };
  if (h[0] === 'op'      && h[1] && h[2]) return { view: 'op', sid: h[1], opId: parseInt(h[2],10) };
  if (h[0] === 'report') return { view: 'report' };
  if (h[0] === 'search'  && h[1]) return { view: 'search', q: decodeURIComponent(h[1]) };
  return { view: 'home' };
};

// ----- Boot -----
async function boot() {
  try {
    const r = await fetch('data/diagrams.json');
    DATA = await r.json();
  } catch (e) {
    document.getElementById('app').innerHTML =
      '<div class="empty-state"><div class="icon">⚠️</div><h2>تعذّر تحميل البيانات</h2><p>تأكد من تشغيل الموقع عبر خادم محلي (وليس بفتح الملف مباشرة).</p></div>';
    return;
  }
  // Flatten
  for (const sid of SECTION_ORDER) {
    if (!DATA[sid]) continue;
    for (const op of DATA[sid].operations) {
      FLAT_OPS.push({ ...op, _sid: sid });
    }
  }
  FLAT_OPS.sort((a,b)=> a.op_id - b.op_id);

  renderSidebar();
  attachGlobalEvents();
  route();
  window.addEventListener('hashchange', route);
}

// ----- Sidebar -----
function renderSidebar() {
  const ul = document.getElementById('modules-nav');
  ul.innerHTML = SECTION_ORDER.map(sid => {
    const meta = SECTION_META[sid];
    const sec = DATA[sid]; if (!sec) return '';
    return `
      <li data-sid="${sid}">
        <a class="module-link" href="#/section/${sid}">
          <span>${meta.icon} ${meta.name}</span>
          <span class="badge">${sec.operations.length}</span>
        </a>
        <ul class="ops-list">
          ${sec.operations.map(op => `
            <li><a href="#/op/${sid}/${op.op_id}">${op.op_id}. ${escapeHtml(op.title)}</a></li>
          `).join('')}
        </ul>
      </li>`;
  }).join('');

  ul.addEventListener('click', e => {
    const li = e.target.closest('li[data-sid]');
    if (!li) return;
    // Toggle expansion if clicking parent link area not when on a sub-op
    if (e.target.closest('.ops-list')) return;
    li.classList.toggle('expanded');
  });
}

// ----- Routing -----
function route() {
  const r = parseHash();
  // Update sidebar active
  document.querySelectorAll('.sidebar .module-link').forEach(a => a.classList.remove('active'));
  document.querySelectorAll('.sidebar .ops-list a').forEach(a => a.classList.remove('active'));
  if (r.sid) {
    const link = document.querySelector(`.sidebar [data-sid="${r.sid}"] .module-link`);
    if (link) link.classList.add('active');
    document.querySelector(`.sidebar [data-sid="${r.sid}"]`)?.classList.add('expanded');
  }
  if (r.view === 'op') {
    const opA = document.querySelector(`.sidebar [data-sid="${r.sid}"] .ops-list a[href="#/op/${r.sid}/${r.opId}"]`);
    if (opA) opA.classList.add('active');
  }

  const app = document.getElementById('app');
  if (r.view === 'home')    renderHome(app);
  else if (r.view === 'section') renderSection(app, r.sid);
  else if (r.view === 'op')      renderOp(app, r.sid, r.opId);
  else if (r.view === 'report')  renderReport(app);
  else if (r.view === 'search')  renderSearch(app, r.q);
  window.scrollTo({top:0, behavior:'smooth'});
}

// ----- Home -----
function renderHome(root) {
  const totalOps = FLAT_OPS.length;
  const totalModules = SECTION_ORDER.filter(s => DATA[s]).length;
  const totalParticipants = new Set();
  FLAT_OPS.forEach(o => (o.participants||[]).forEach(p => totalParticipants.add(p)));

  root.innerHTML = `
    <nav class="breadcrumb"><span class="current">الصفحة الرئيسية</span></nav>
    <section class="hero">
      <h1>بوابة توثيق نظام إدارة المدارس</h1>
      <p>توثيق فني شامل لـ <strong>${totalOps}</strong> عملية موزعة على <strong>${totalModules}</strong> وحدات نظام، مع مخططات تسلسل (Sequence Diagrams) معاد بناؤها بصيغة Mermaid قابلة للقراءة والتعديل.</p>
      <div class="hero-stats">
        <div class="stat"><div class="n">${totalModules}</div><div class="l">وحدات النظام</div></div>
        <div class="stat"><div class="n">${totalOps}</div><div class="l">عملية موثقة</div></div>
        <div class="stat"><div class="n">${totalOps}</div><div class="l">مخطط تسلسل</div></div>
        <div class="stat"><div class="n">${totalParticipants.size||'—'}</div><div class="l">مشارك / كائن</div></div>
      </div>
    </section>

    <div class="section-title">
      <h2>وحدات النظام</h2>
      <span class="sub">اختر وحدة لعرض عملياتها</span>
    </div>
    <div class="modules-grid">
      ${SECTION_ORDER.filter(s=>DATA[s]).map(sid => {
        const m = SECTION_META[sid]; const sec = DATA[sid];
        return `
          <a class="module-card" href="#/section/${sid}">
            <div class="icon">${m.icon}</div>
            <h3>${m.name}</h3>
            <p>${m.desc}</p>
            <div class="meta"><span>العمليات ${m.range}</span><strong>${sec.operations.length} عملية</strong></div>
          </a>`;
      }).join('')}
    </div>

    <div class="section-title" style="margin-top:32px">
      <h2>روابط سريعة</h2>
    </div>
    <div class="modules-grid">
      <a class="module-card" href="Review_Report.html">
        <div class="icon" style="background:linear-gradient(135deg,var(--success),#0e7e3a)">✅</div>
        <h3>تقرير المراجعة</h3>
        <p>نسبة الثقة لكل مخطط والعناصر التي تحتاج مراجعة بشرية.</p>
        <div class="meta"><span>Review_Report.html</span><strong>عرض</strong></div>
      </a>
      <a class="module-card" href="#/op/section1/1">
        <div class="icon" style="background:linear-gradient(135deg,var(--accent),#0a85b8)">🚀</div>
        <h3>ابدأ من العملية الأولى</h3>
        <p>تجوّل عبر جميع العمليات بترتيبها الرسمي من 1 إلى ${totalOps}.</p>
        <div class="meta"><span>الترتيب الرسمي</span><strong>ابدأ</strong></div>
      </a>
    </div>
  `;
}

// ----- Module/Section page -----
function renderSection(root, sid) {
  const meta = SECTION_META[sid]; const sec = DATA[sid];
  if (!sec) { root.innerHTML = '<div class="empty-state"><div class="icon">❓</div>وحدة غير موجودة</div>'; return; }

  root.innerHTML = `
    <nav class="breadcrumb">
      <a href="#/">الرئيسية</a><span class="sep">›</span>
      <span class="current">${meta.name}</span>
    </nav>
    <div class="module-header">
      <div class="icon">${meta.icon}</div>
      <div>
        <h1>${meta.name}</h1>
        <div class="meta">${meta.desc} · العمليات ${meta.range}</div>
      </div>
    </div>
    <div class="ops-search">
      <input id="ops-filter" type="search" placeholder="فلتر داخل عمليات هذه الوحدة..." />
      <div class="ops-counter" id="ops-counter">${sec.operations.length} عملية</div>
    </div>
    <div class="ops-grid" id="ops-grid">
      ${sec.operations.map(op => `
        <a class="op-card" href="#/op/${sid}/${op.op_id}" data-title="${escapeHtml(op.title)}">
          <span class="op-num">#${op.op_id}</span>
          <div>
            <div class="op-title">${escapeHtml(op.title)}</div>
            <div class="op-meta">${(op.participants||[]).length} مشارك · ${(op.messages||[]).length} رسالة</div>
          </div>
        </a>
      `).join('')}
    </div>
  `;

  const inp = document.getElementById('ops-filter');
  inp.addEventListener('input', () => {
    const q = inp.value.trim().toLowerCase();
    let visible = 0;
    document.querySelectorAll('#ops-grid .op-card').forEach(card => {
      const match = !q || card.dataset.title.toLowerCase().includes(q) || card.textContent.toLowerCase().includes(q);
      card.style.display = match ? '' : 'none';
      if (match) visible++;
    });
    document.getElementById('ops-counter').textContent = `${visible} عملية`;
  });
}

// ----- Operation page -----
function renderOp(root, sid, opId) {
  const sec = DATA[sid];
  if (!sec) { root.innerHTML = '<div class="empty-state"><div class="icon">❓</div>وحدة غير موجودة</div>'; return; }
  const op = sec.operations.find(o => o.op_id === opId);
  if (!op) { root.innerHTML = '<div class="empty-state"><div class="icon">❓</div>عملية غير موجودة</div>'; return; }
  const meta = SECTION_META[sid];

  // Prev/Next within section
  const idx = sec.operations.findIndex(o => o.op_id === opId);
  const prev = idx > 0 ? sec.operations[idx-1] : null;
  const next = idx < sec.operations.length-1 ? sec.operations[idx+1] : null;

  const confidence = op.confidence != null ? op.confidence : null;
  let confClass = 'success'; let confLabel = 'ثقة عالية';
  if (confidence != null) {
    if (confidence < 70) { confClass = 'danger'; confLabel = 'ثقة منخفضة'; }
    else if (confidence < 85) { confClass = 'warning'; confLabel = 'ثقة متوسطة'; }
  }

  root.innerHTML = `
    <nav class="breadcrumb">
      <a href="#/">الرئيسية</a><span class="sep">›</span>
      <a href="#/section/${sid}">${meta.name}</a><span class="sep">›</span>
      <span class="current">العملية ${op.op_id}</span>
    </nav>

    <div class="op-header">
      <span class="op-num-large">عملية #${op.op_id}</span>
      <h1>${escapeHtml(op.title)}</h1>
      ${op.description ? `<p class="description">${escapeHtml(op.description)}</p>` : ''}
      <div class="badges">
        <span class="badge info">${meta.icon} ${meta.name}</span>
        <span class="badge">${(op.participants||[]).length} مشارك</span>
        <span class="badge">${(op.messages||[]).length} رسالة</span>
        ${confidence!=null ? `<span class="badge ${confClass}">${confLabel} · ${confidence}%</span>` : ''}
        ${op.has_alt ? '<span class="badge warning">يحتوي بدائل (alt)</span>' : ''}
        ${op.has_loop ? '<span class="badge info">يحتوي حلقات (loop)</span>' : ''}
      </div>
    </div>

    <div class="op-section">
      <h2><span class="icon">📊</span> مخطط التسلسل (Sequence Diagram)</h2>
      ${op.mermaid ? `
        <div class="diagram-box"><pre class="mermaid">${escapeHtml(op.mermaid)}</pre></div>
        <div class="code-toggle">
          <button onclick="toggleCode(this)">عرض/إخفاء مصدر Mermaid</button>
          <button onclick="copyCode(this)">📋 نسخ المصدر</button>
        </div>
        <pre class="code-block">${escapeHtml(op.mermaid)}</pre>
      ` : `<p style="color:var(--text-muted)">⏳ المخطط قيد المعالجة…</p>`}
    </div>

    ${(op.participants||[]).length ? `
      <div class="op-section">
        <h2><span class="icon">👥</span> المشاركون (Participants)</h2>
        <div class="participants">
          ${op.participants.map(p => `<span class="participant"><span class="dot"></span>${escapeHtml(p)}</span>`).join('')}
        </div>
      </div>` : ''}

    ${op.summary ? `
      <div class="op-section">
        <h2><span class="icon">📝</span> ملخص التفاعلات</h2>
        <p style="margin:0;color:var(--text-soft);font-size:14px">${escapeHtml(op.summary)}</p>
      </div>` : ''}

    ${(op.notes||[]).length ? `
      <div class="op-section">
        <h2><span class="icon">📌</span> ملاحظات وشروط</h2>
        <ul class="notes-list">
          ${op.notes.map(n => `<li>${escapeHtml(n)}</li>`).join('')}
        </ul>
      </div>` : ''}

    <nav class="op-nav">
      <a href="${prev ? `#/op/${sid}/${prev.op_id}` : '#'}" class="${prev?'':'disabled'}">
        <span class="arrow">‹ السابقة</span>
        <span class="label">${prev ? escapeHtml(prev.op_id+'. '+prev.title) : '—'}</span>
      </a>
      <a href="#/section/${sid}" style="text-align:center;flex:0 0 auto;min-width:auto;padding:14px 20px">
        <span class="arrow">⌂</span>
        <span class="label">العودة للوحدة</span>
      </a>
      <a class="next ${next?'':'disabled'}" href="${next ? `#/op/${sid}/${next.op_id}` : '#'}">
        <span class="arrow">التالية ›</span>
        <span class="label">${next ? escapeHtml(next.op_id+'. '+next.title) : '—'}</span>
      </a>
    </nav>
  `;

  // Mermaid render
  if (window.mermaid && op.mermaid) {
    try {
      window.mermaid.run({ querySelector: '.mermaid', suppressErrors: false });
    } catch(e) {
      console.warn('mermaid error', e);
    }
  }
}

// ----- Search -----
function renderSearch(root, q) {
  q = (q||'').trim().toLowerCase();
  const results = FLAT_OPS.filter(op => {
    if (!q) return false;
    const hay = [
      op.title, op.summary||'',
      (op.participants||[]).join(' '),
      (op.notes||[]).join(' '),
      (op.messages||[]).map(m=>m.label||'').join(' '),
      op.mermaid||'',
      String(op.op_id),
    ].join(' ').toLowerCase();
    return hay.includes(q);
  });

  root.innerHTML = `
    <nav class="breadcrumb">
      <a href="#/">الرئيسية</a><span class="sep">›</span>
      <span class="current">نتائج البحث</span>
    </nav>
    <div class="op-header">
      <h1>نتائج البحث عن: "${escapeHtml(q)}"</h1>
      <p class="description">${results.length} نتيجة</p>
    </div>
    <div class="ops-grid">
      ${results.slice(0,200).map(op => {
        const m = SECTION_META[op._sid];
        return `<a class="op-card" href="#/op/${op._sid}/${op.op_id}">
          <span class="op-num">#${op.op_id}</span>
          <div>
            <div class="op-title">${escapeHtml(op.title)}</div>
            <div class="op-meta">${m.icon} ${m.name}</div>
          </div>
        </a>`;
      }).join('') || '<div class="empty-state"><div class="icon">🔍</div>لا توجد نتائج</div>'}
    </div>
  `;
}

// ----- Global search (header) -----
function attachGlobalEvents() {
  const inp = document.getElementById('global-search');
  const res = document.getElementById('global-search-results');

  function performSearch() {
    const q = inp.value.trim().toLowerCase();
    if (q.length < 2) { res.classList.remove('open'); res.innerHTML=''; return; }
    const matches = FLAT_OPS.filter(op => {
      const hay = [
        op.title, String(op.op_id),
        (op.participants||[]).join(' '),
        op.summary||'',
        (op.messages||[]).map(m=>m.label||'').join(' '),
      ].join(' ').toLowerCase();
      return hay.includes(q);
    }).slice(0, 20);
    if (!matches.length) {
      res.innerHTML = '<div class="empty">لا توجد نتائج</div>';
    } else {
      res.innerHTML = `<div class="group-label">${matches.length} نتيجة</div>` +
        matches.map(op => `
          <a href="#/op/${op._sid}/${op.op_id}">
            <span>${op.op_id}. ${escapeHtml(op.title)}</span>
            <small>${SECTION_META[op._sid].icon} ${SECTION_META[op._sid].name}</small>
          </a>`).join('');
    }
    res.classList.add('open');
  }
  inp.addEventListener('input', performSearch);
  inp.addEventListener('focus', performSearch);
  inp.addEventListener('keydown', e => {
    if (e.key === 'Enter' && inp.value.trim().length >= 2) {
      res.classList.remove('open');
      location.hash = '#/search/'+encodeURIComponent(inp.value.trim());
    } else if (e.key === 'Escape') {
      res.classList.remove('open'); inp.blur();
    }
  });
  document.addEventListener('click', e => {
    if (!e.target.closest('.header-search')) res.classList.remove('open');
  });

  // Theme toggle
  const tbtn = document.getElementById('theme-toggle');
  const apply = (mode) => {
    document.documentElement.dataset.theme = mode;
    tbtn.textContent = mode === 'dark' ? '☀️' : '🌙';
    localStorage.setItem('theme', mode);
    // Re-init mermaid with theme
    if (window.mermaid) {
      window.mermaid.initialize({
        startOnLoad: false,
        theme: mode === 'dark' ? 'dark' : 'default',
        sequence: { showSequenceNumbers: true, mirrorActors: true, actorMargin: 50, messageAlign: 'center' },
        fontFamily: "'Noto Sans Arabic', 'Tajawal', 'Cairo', sans-serif",
      });
      // Re-render existing mermaid blocks
      document.querySelectorAll('.mermaid').forEach(el => {
        if (el.dataset.processed === 'true') {
          const src = el.dataset.src || el.textContent;
          el.dataset.src = src;
          el.removeAttribute('data-processed');
          el.innerHTML = src;
        }
      });
      try { window.mermaid.run({ querySelector: '.mermaid' }); } catch(e){}
    }
  };
  const saved = localStorage.getItem('theme') || (matchMedia('(prefers-color-scheme: dark)').matches?'dark':'light');
  apply(saved);
  tbtn.addEventListener('click', ()=> apply(document.documentElement.dataset.theme === 'dark' ? 'light' : 'dark'));
}

// ----- Report (calls Review_Report.html as separate page) -----
function renderReport(root) {
  root.innerHTML = `<div class="op-header"><h1>تقرير المراجعة</h1>
   <p class="description">لعرض تقرير المراجعة الكامل، انتقل إلى:
   <a href="Review_Report.html">Review_Report.html</a></p></div>`;
}

// ----- Helpers -----
function escapeHtml(s) {
  return String(s ?? '').replace(/[&<>"']/g, c => ({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[c]));
}
function toggleCode(btn) {
  const block = btn.closest('.op-section').querySelector('.code-block');
  block.classList.toggle('open');
}
function copyCode(btn) {
  const block = btn.closest('.op-section').querySelector('.code-block');
  navigator.clipboard.writeText(block.textContent).then(()=>{
    const t = btn.textContent; btn.textContent = '✓ تم النسخ';
    setTimeout(()=>btn.textContent=t, 1500);
  });
}

window.toggleCode = toggleCode;
window.copyCode = copyCode;

document.addEventListener('DOMContentLoaded', boot);
