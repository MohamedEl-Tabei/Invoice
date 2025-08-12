import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[appSpinner]'
})
export class SpinnerDirective {

  constructor(private spinner:ElementRef) { }
  @Input() colorNumber: string = '1';
  ngOnInit() {
    this.spinner.nativeElement.classList.add('spinner-border',"text-"+this.colorNumber);
  }

}
