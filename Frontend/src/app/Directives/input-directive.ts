import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[appInput]'
})
export class InputDirective {
  @Input()
  colorNumber: "1" | "2" = "1";
  
  constructor(private input: ElementRef) { }
  ngAfterViewInit() {
    if (this.input.nativeElement.type === 'checkbox')
      this.input.nativeElement.classList
        .add("form-check-input", "form-check-input-" + this.colorNumber);


    else
      this.input.nativeElement.classList.add("form-control","form-control-"+this.colorNumber);


  }
}
