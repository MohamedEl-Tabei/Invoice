import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appLabel]'
})
export class LabelDirective {

  constructor(private label: ElementRef) { }
  ngOnInit() {
    this.label.nativeElement.classList.add('form-label', 'text-gray-700', 'font-medium', 'dark:text-gray-500','text-capitalize');
  }


}
