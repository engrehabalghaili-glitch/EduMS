import { TestBed } from '@angular/core/testing';
import { AppTag } from './tag.component';

describe('AppTag', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppTag],
    }).compileComponents();
  });

  it('should create', () => {
    const fixture = TestBed.createComponent(AppTag);
    fixture.componentRef.setInput('value', 'test');
    fixture.detectChanges();
    expect(fixture.componentInstance).toBeTruthy();
  });

  it('should render value', () => {
    const fixture = TestBed.createComponent(AppTag);
    fixture.componentRef.setInput('value', 'نشط');
    fixture.detectChanges();
    const el = fixture.nativeElement as HTMLElement;
    expect(el.textContent).toContain('نشط');
  });

  it('should default severity to info', () => {
    const fixture = TestBed.createComponent(AppTag);
    fixture.componentRef.setInput('value', 'test');
    fixture.detectChanges();
    expect(fixture.componentInstance.severity()).toBe('info');
  });
});
