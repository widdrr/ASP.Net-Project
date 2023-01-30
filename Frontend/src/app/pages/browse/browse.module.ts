import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { MatTableModule } from '@angular/material/table'
import { MatToolbarModule } from '@angular/material/toolbar'
import { GameComponent } from './game/game.component';
import { OwnCheckDirective } from '../../core/directives/own-check.directive';
import { PipesModule } from '../../core/pipes/pipes.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    GameComponent,
    OwnCheckDirective,
  ],
  imports: [
    PipesModule,
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatToolbarModule,
    RouterModule,
  ]
})
export class BrowseModule { }
