import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';
import { LibraryService } from '../services/library.service';

@Directive({
  selector: '[appOwnCheck]'
})
export class OwnCheckDirective implements OnInit {

  @Input() appOwnCheck : string = ""
  constructor(private readonly libraryService: LibraryService,
              private readonly renderer: Renderer2,
              private button: ElementRef) { }

  ngOnInit()
    {
      if (this.libraryService.ownsGame(this.appOwnCheck)) {
      this.renderer.setProperty(this.button.nativeElement, "innerHTML", "OWNED");
      this.renderer.setAttribute(this.button.nativeElement, "disabled", "true");
    }
    else {
      this.renderer.setProperty(this.button.nativeElement, "innerHTML", "ADD TO CART");
    }


  }
}
