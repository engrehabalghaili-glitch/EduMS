import { Directive, ElementRef, HostListener, output, inject } from '@angular/core';

@Directive({ selector: '[appClickOutside]', standalone: true })
export class ClickOutsideDirective {
  readonly appClickOutside = output<void>();
  private readonly el = inject(ElementRef);

  @HostListener('document:click', ['$event'])
  onClick(event: MouseEvent) {
    if (!this.el.nativeElement.contains(event.target as Node)) {
      this.appClickOutside.emit();
    }
  }
}
