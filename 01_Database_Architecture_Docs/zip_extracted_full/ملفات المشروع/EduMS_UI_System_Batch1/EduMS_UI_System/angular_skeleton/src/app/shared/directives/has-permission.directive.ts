import { Directive, Input, TemplateRef, ViewContainerRef, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../../core/auth/auth.service';

/**
 * Structural directive that shows/hides element based on user roles
 * Usage:
 *   <button *hasPermission="['principal', 'office_sup']">اعتماد</button>
 *   <div *hasPermission="['*']">للجميع</div>
 */
@Directive({ selector: '[hasPermission]', standalone: true })
export class HasPermissionDirective implements OnInit, OnDestroy {
  private requiredRoles: string[] = [];
  private hasView = false;
  private sub?: Subscription;

  @Input() set hasPermission(roles: string | string[]) {
    this.requiredRoles = Array.isArray(roles) ? roles : [roles];
    this.updateView();
  }

  constructor(
    private template: TemplateRef<any>,
    private view: ViewContainerRef,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    // Re-evaluate when user changes
    this.sub = this.auth.currentUser$.subscribe(() => this.updateView());
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  private updateView(): void {
    const allowed = this.auth.hasAnyRole(this.requiredRoles);
    if (allowed && !this.hasView) {
      this.view.createEmbeddedView(this.template);
      this.hasView = true;
    } else if (!allowed && this.hasView) {
      this.view.clear();
      this.hasView = false;
    }
  }
}
