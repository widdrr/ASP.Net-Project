import { AfterViewInit, Directive, ElementRef, Input, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appColorSum]'
})
export class ColorSumDirective implements AfterViewInit{

  @Input() appColorSum :string = ''
  constructor(private readonly renderer: Renderer2,
              private readonly text: ElementRef) { }

  ngAfterViewInit() {
    if (this.appColorSum == "Purchase") {
      this.renderer.setProperty(this.text.nativeElement, "innerHTML", "-" + this.text.nativeElement.innerHTML);
      this.renderer.setStyle(this.text.nativeElement, "color", "red");
    }
    else {
      this.renderer.setProperty(this.text.nativeElement, "innerHTML", "+" + this.text.nativeElement.innerHTML);
      this.renderer.setStyle(this.text.nativeElement, "color", "green");
    }
  }

}
