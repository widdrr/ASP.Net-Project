import { AfterViewInit, Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';
import { LibraryService } from '../services/library.service';
import { TransactionService } from '../services/transaction.service';

@Directive({
  selector: '[appOwnCheck]'
})
export class OwnCheckDirective implements AfterViewInit {

  @Input() appOwnCheck : string = ""
  constructor(private readonly libraryService: LibraryService,
              private readonly transactionService: TransactionService,
              private readonly renderer: Renderer2,
              private button: ElementRef) { }

  ngAfterViewInit(){
    if (this.libraryService.ownsGame(this.appOwnCheck)) {
      this.renderer.setProperty(this.button.nativeElement, "innerHTML", "OWNED");
      this.renderer.setAttribute(this.button.nativeElement, "disabled", "true");
    }
    else if (this.transactionService.isInCart(this.appOwnCheck))
    {
      this.renderer.setProperty(this.button.nativeElement, "innerHTML", "IN CART");
      this.renderer.setAttribute(this.button.nativeElement, "disabled", "true");
    }
    else {
      this.renderer.setProperty(this.button.nativeElement, "innerHTML", "ADD TO CART");
    }


  }
}
