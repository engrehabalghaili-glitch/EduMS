import { Directive, ElementRef, OnInit, inject } from '@angular/core';

@Directive({ selector: '[appAutoFocus]', standalone: true })
export class AutoFocusDirective implements OnInit {
  private readonly el = inject<ElementRef<HTMLElement>>(ElementRef);
  ngOnInit() {
    this.el.nativeElement.focus();
  }
}
