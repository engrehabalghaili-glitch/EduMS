/* =========================================================================
   EduMS Enterprise — Core SPA Engine
   Lightweight Vanilla JS implementation of:
   - Role-based dynamic views
   - Hash-based routing
   - Component rendering
   - State management
   ========================================================================= */

(function (global) {
  'use strict';

  const EduMS = {
    state: {
      currentRole: 'principal',
      sidebarCollapsed: false,
      isLoggedIn: true,
      route: '#/dashboard'
    },

    /* ============= UTILITIES ============= */
    el(tag, props = {}, children = []) {
      const node = document.createElement(tag);
      Object.entries(props).forEach(([k, v]) => {
        if (k === 'className') node.className = v;
        else if (k === 'innerHTML') node.innerHTML = v;
        else if (k.startsWith('on') && typeof v === 'function') {
          node.addEventListener(k.slice(2).toLowerCase(), v);
        } else if (k === 'dataset') {
          Object.entries(v).forEach(([dk, dv]) => node.dataset[dk] = dv);
        } else {
          node.setAttribute(k, v);
        }
      });
      (Array.isArray(children) ? children : [children]).forEach(c => {
        if (c == null) return;
        if (typeof c === 'string') node.appendChild(document.createTextNode(c));
        else node.appendChild(c);
      });
      return node;
    },

    qs(selector) { return document.querySelector(selector); },
    qsa(selector) { return document.querySelectorAll(selector); },

    /* ============= PERMISSIONS ============= */
    can(roleOrRoles, currentRole = null) {
      const role = currentRole || EduMS.state.currentRole;
      if (!roleOrRoles) return true;
      const arr = Array.isArray(roleOrRoles) ? roleOrRoles : [roleOrRoles];
      return arr.includes('*') || arr.includes(role);
    },

    /* ============= ROLE SWITCHING ============= */
    setRole(roleId) {
      const role = window.EduMSData.roles.find(r => r.id === roleId);
      if (!role) return;
      EduMS.state.currentRole = roleId;
      EduMS.updateUser(role);
      EduMS.renderSidebar();
      EduMS.renderDashboard();
      EduMS.notify({ type: 'info', title: 'تم تبديل الدور', msg: `الواجهة الآن لـ: ${role.name}` });
    },

    updateUser(role) {
      const userName = EduMS.qs('#sidebar-user-name');
      const userRole = EduMS.qs('#sidebar-user-role');
      const userAvatar = EduMS.qs('#sidebar-user-avatar');
      if (userName) userName.textContent = window.EduMSData.currentUser.name;
      if (userRole) userRole.textContent = role.name;
      if (userAvatar) {
        userAvatar.textContent = role.avatar;
        userAvatar.style.background = `linear-gradient(135deg, ${role.color}, ${role.color}aa)`;
      }
    },

    /* ============= SIDEBAR RENDERING (DYNAMIC) ============= */
    renderSidebar() {
      const nav = EduMS.qs('#sidebar-nav');
      if (!nav) return;
      nav.innerHTML = '';

      const items = window.EduMSData.menuItems.filter(item =>
        EduMS.can(item.roles)
      );

      let lastSection = null;
      items.forEach(item => {
        if (item.type === 'section') {
          const sectionEl = EduMS.el('div', { className: 'sidebar-section-title' }, item.label);
          nav.appendChild(sectionEl);
          lastSection = item;
        } else {
          const linkEl = EduMS.el('a', {
            className: 'nav-item' + (EduMS.state.route === item.route ? ' active' : ''),
            href: item.route,
            dataset: { route: item.route }
          });
          linkEl.innerHTML = `
            <span class="nav-icon">${item.icon || '•'}</span>
            <span class="nav-text">${item.label}</span>
            ${item.badge ? `<span class="nav-badge">${item.badge}</span>` : ''}
          `;
          linkEl.addEventListener('click', (e) => {
            e.preventDefault();
            EduMS.navigate(item.route);
          });
          nav.appendChild(linkEl);
        }
      });
    },

    /* ============= ROUTER ============= */
    navigate(route) {
      EduMS.state.route = route;
      window.location.hash = route;
      EduMS.renderSidebar();   // update active state
      EduMS.renderPage(route);
    },

    renderPage(route) {
      // For Foundation Package, mainly render dashboard.
      // Other routes show "coming soon" placeholder.
      const content = EduMS.qs('#main-page-content');
      if (!content) return;

      if (route === '#/dashboard' || !route) {
        EduMS.renderDashboard();
        return;
      }

      // Update breadcrumb + title
      const breadcrumb = EduMS.qs('#page-breadcrumb');
      const pageTitle  = EduMS.qs('#page-title');
      const pageSub    = EduMS.qs('#page-subtitle');

      const menuItem = window.EduMSData.menuItems.find(m => m.route === route);
      if (pageTitle) pageTitle.textContent = menuItem ? menuItem.label : 'صفحة';
      if (pageSub)   pageSub.textContent = 'هذه الصفحة ستُسلَّم في الدفعات القادمة';

      content.innerHTML = `
        <div class="card">
          <div class="card-body">
            <div class="empty-state">
              <div class="empty-state-icon">🚧</div>
              <div class="empty-state-title">قيد التطوير</div>
              <p class="empty-state-desc">
                هذه الصفحة (<span class="text-mono">${route}</span>) ستُسلَّم في إحدى الدفعات القادمة من المشروع.
                الدفعة الأولى تركّز على Master Shell SPA + لوحات التحكم + مكتبة المكونات.
              </p>
              <button class="btn btn-primary" onclick="EduMS.navigate('#/dashboard')">العودة إلى لوحة التحكم</button>
            </div>
          </div>
        </div>
      `;
    },

    /* ============= DASHBOARD RENDERING (ROLE-AWARE) ============= */
    renderDashboard() {
      const content = EduMS.qs('#main-page-content');
      if (!content) return;

      const role = EduMS.state.currentRole;
      const roleData = window.EduMSData.roles.find(r => r.id === role);
      const stats = window.EduMSData.dashboardStats[role] || window.EduMSData.dashboardStats.principal;

      const pageTitle  = EduMS.qs('#page-title');
      const pageSub    = EduMS.qs('#page-subtitle');
      if (pageTitle) pageTitle.textContent = `لوحة التحكم — ${roleData.name}`;
      if (pageSub)   pageSub.textContent = `مرحباً بعودتك! إليك ملخص نشاط النظام اليوم`;

      // Build stat cards
      const statsHtml = stats.map(s => `
        <div class="stat-card stat-${s.variant}">
          <div class="stat-icon">${s.icon}</div>
          <div class="stat-content">
            <div class="stat-label">${s.label}</div>
            <div class="stat-value">${s.value}</div>
            <div class="stat-change ${s.trend}">${s.trend === 'up' ? '↗' : '↘'} ${s.change}</div>
          </div>
        </div>
      `).join('');

      // Charts area – different for different roles
      const chartsHtml = `
        <div class="grid grid-cols-2 mb-6">
          <div class="card">
            <div class="card-header">
              <div>
                <div class="card-title">اتجاه الحضور هذا الأسبوع</div>
                <div class="card-subtitle">يومياً منذ السبت</div>
              </div>
              <span class="badge badge-success badge-dot">+1.4%</span>
            </div>
            <div class="card-body">
              <canvas id="chart-attendance" height="220"></canvas>
            </div>
          </div>
          <div class="card">
            <div class="card-header">
              <div>
                <div class="card-title">توزيع التقديرات</div>
                <div class="card-subtitle">إجمالي 1,247 طالب</div>
              </div>
            </div>
            <div class="card-body">
              <canvas id="chart-grades" height="220"></canvas>
            </div>
          </div>
        </div>
      `;

      // Recent activities timeline
      const activitiesHtml = window.EduMSData.recentActivities.map(a => `
        <div class="flex gap-3 p-3" style="border-bottom: 1px solid var(--color-gray-100);">
          <div style="width:42px; height:42px; flex-shrink:0; border-radius:50%; display:flex; align-items:center; justify-content:center; background: var(--color-${a.color}-50); color: var(--color-${a.color}-600); font-size:20px;">
            ${a.icon}
          </div>
          <div class="flex-1">
            <div class="font-semibold text-sm">${a.title}</div>
            <div class="text-xs text-muted">${a.desc}</div>
            <div class="text-xs text-muted mt-2">${a.user} • ${a.time}</div>
          </div>
        </div>
      `).join('');

      // Announcements list
      const annHtml = window.EduMSData.announcements.map(ann => `
        <div class="flex gap-3 p-3" style="border-bottom: 1px solid var(--color-gray-100);">
          <div style="width:6px; background: var(--color-${ann.type==='urgent'?'danger':ann.type==='official'?'gold':'info'}-500); border-radius: 3px;"></div>
          <div class="flex-1">
            <div class="flex items-center gap-2 mb-2">
              <span class="badge badge-${ann.type==='urgent'?'danger':ann.type==='official'?'gold':'info'}">${ann.priority}</span>
              ${!ann.isRead ? '<span class="badge badge-primary">جديد</span>' : ''}
            </div>
            <div class="font-semibold text-sm">${ann.title}</div>
            <div class="text-xs text-muted mt-2">${ann.source} • ${ann.date}</div>
          </div>
        </div>
      `).join('');

      content.innerHTML = `
        <!-- Stats Grid -->
        <div class="grid grid-cols-${stats.length >= 6 ? 3 : stats.length} mb-6">
          ${statsHtml}
        </div>

        <!-- Charts -->
        ${chartsHtml}

        <!-- Two-column: Activities + Announcements -->
        <div class="grid grid-cols-2">
          <div class="card">
            <div class="card-header">
              <div>
                <div class="card-title">📋 آخر النشاطات</div>
                <div class="card-subtitle">تحديثات النظام المباشرة</div>
              </div>
              <a href="#" class="btn btn-ghost btn-sm">عرض الكل ←</a>
            </div>
            <div style="max-height: 420px; overflow-y: auto;">
              ${activitiesHtml}
            </div>
          </div>

          <div class="card">
            <div class="card-header">
              <div>
                <div class="card-title">📣 التعاميم والإعلانات</div>
                <div class="card-subtitle">آخر التعاميم الواردة</div>
              </div>
              <a href="#" class="btn btn-ghost btn-sm">عرض الكل ←</a>
            </div>
            <div style="max-height: 420px; overflow-y: auto;">
              ${annHtml}
            </div>
          </div>
        </div>
      `;

      // Render charts (lazy)
      setTimeout(() => {
        EduMS.renderCharts();
      }, 100);
    },

    /* ============= CHARTS (Chart.js) ============= */
    renderCharts() {
      if (typeof Chart === 'undefined') return;

      // Attendance Line Chart
      const attCanvas = EduMS.qs('#chart-attendance');
      if (attCanvas) {
        if (attCanvas._chart) attCanvas._chart.destroy();
        attCanvas._chart = new Chart(attCanvas, {
          type: 'line',
          data: {
            labels: window.EduMSData.charts.attendanceTrend.labels,
            datasets: [{
              label: 'نسبة الحضور %',
              data: window.EduMSData.charts.attendanceTrend.data,
              borderColor: '#1E3A8A',
              backgroundColor: 'rgba(30, 58, 138, 0.12)',
              tension: 0.4,
              fill: true,
              pointBackgroundColor: '#D4AF37',
              pointBorderColor: '#fff',
              pointBorderWidth: 2,
              pointRadius: 5,
              pointHoverRadius: 7,
              borderWidth: 3
            }]
          },
          options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
              legend: { display: false }
            },
            scales: {
              y: { beginAtZero: false, suggestedMin: 85, suggestedMax: 100, ticks: { font: { family: 'Cairo' }, callback: v => v + '%' } },
              x: { ticks: { font: { family: 'Cairo' } } }
            }
          }
        });
      }

      // Grades doughnut
      const gradesCanvas = EduMS.qs('#chart-grades');
      if (gradesCanvas) {
        if (gradesCanvas._chart) gradesCanvas._chart.destroy();
        gradesCanvas._chart = new Chart(gradesCanvas, {
          type: 'doughnut',
          data: {
            labels: window.EduMSData.charts.gradesDistribution.labels,
            datasets: [{
              data: window.EduMSData.charts.gradesDistribution.data,
              backgroundColor: window.EduMSData.charts.gradesDistribution.colors,
              borderWidth: 2,
              borderColor: '#fff'
            }]
          },
          options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
              legend: { position: 'bottom', labels: { font: { family: 'Cairo', size: 11 }, padding: 10, usePointStyle: true } }
            },
            cutout: '60%'
          }
        });
      }
    },

    /* ============= TOASTS / NOTIFICATIONS ============= */
    notify({ type = 'info', title = '', msg = '', duration = 3500 }) {
      let container = EduMS.qs('#toast-container');
      if (!container) {
        container = EduMS.el('div', { id: 'toast-container', className: 'toast-container' });
        document.body.appendChild(container);
      }
      const icons = { success: '✅', danger: '⚠️', warning: '⚠️', info: 'ℹ️' };
      const toast = EduMS.el('div', { className: `toast toast-${type}` });
      toast.innerHTML = `
        <div class="toast-icon">${icons[type] || 'ℹ️'}</div>
        <div class="toast-body">
          <div class="toast-title">${title}</div>
          ${msg ? `<div class="toast-msg">${msg}</div>` : ''}
        </div>
      `;
      container.appendChild(toast);
      setTimeout(() => { toast.style.opacity = '0'; toast.style.transform = 'translateX(-20px)'; setTimeout(() => toast.remove(), 250); }, duration);
    },

    /* ============= MODALS ============= */
    openModal(modalId) {
      const m = EduMS.qs(`#${modalId}`);
      if (m) m.classList.add('is-open');
    },
    closeModal(modalId) {
      const m = EduMS.qs(`#${modalId}`);
      if (m) m.classList.remove('is-open');
    },

    /* ============= INITIALIZATION ============= */
    init() {
      // Sidebar toggle
      const toggleBtn = EduMS.qs('#sidebar-toggle');
      if (toggleBtn) {
        toggleBtn.addEventListener('click', () => {
          const sidebar = EduMS.qs('#sidebar');
          sidebar.classList.toggle('collapsed');
          EduMS.state.sidebarCollapsed = !EduMS.state.sidebarCollapsed;
        });
      }

      // Role switcher
      const roleSelect = EduMS.qs('#role-switcher');
      if (roleSelect) {
        roleSelect.innerHTML = window.EduMSData.roles.map(r =>
          `<option value="${r.id}" ${r.id === EduMS.state.currentRole ? 'selected' : ''}>${r.name}</option>`
        ).join('');
        roleSelect.addEventListener('change', (e) => EduMS.setRole(e.target.value));
      }

      // Logout link
      const logoutBtn = EduMS.qs('#logout-btn');
      if (logoutBtn) {
        logoutBtn.addEventListener('click', (e) => {
          e.preventDefault();
          if (confirm('تأكيد تسجيل الخروج؟')) {
            window.location.href = 'auth/login.html';
          }
        });
      }

      // Handle hash changes
      window.addEventListener('hashchange', () => {
        EduMS.state.route = window.location.hash || '#/dashboard';
        EduMS.renderPage(EduMS.state.route);
      });

      // Modal close handlers
      document.addEventListener('click', (e) => {
        if (e.target.classList.contains('modal-close') || e.target.classList.contains('modal-backdrop')) {
          const modal = e.target.closest('.modal-backdrop');
          if (modal && e.target === modal) modal.classList.remove('is-open');
          if (e.target.classList.contains('modal-close')) {
            const m = e.target.closest('.modal-backdrop');
            if (m) m.classList.remove('is-open');
          }
        }
      });

      // Initial render
      EduMS.renderSidebar();
      const initialRoute = window.location.hash || '#/dashboard';
      EduMS.state.route = initialRoute;
      EduMS.renderPage(initialRoute);

      // Welcome toast
      setTimeout(() => {
        EduMS.notify({ type: 'success', title: 'مرحباً بعودتك!', msg: 'تم تسجيل دخولك بنجاح', duration: 3000 });
      }, 500);
    }
  };

  global.EduMS = EduMS;

  // Auto-init when DOM ready
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', EduMS.init);
  } else {
    EduMS.init();
  }

})(window);
