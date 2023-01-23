import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { MatTableModule } from '@angular/material/table'
import { MatToolbarModule } from '@angular/material/toolbar'
import { GameComponent } from './game/game.component';
import { PricePipe } from '../../core/pipes/price.pipe';
import { OwnCheckDirective } from '../../core/directives/own-check.directive';

@NgModule({
  declarations: [
    GameComponent,
    PricePipe,
    OwnCheckDirective,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatToolbarModule,
  ]
})
export class BrowseModule { }
