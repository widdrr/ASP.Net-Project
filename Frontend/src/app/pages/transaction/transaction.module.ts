import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryComponent } from './history/history.component';
import { DetailsComponent } from './details/details.component';
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { MatTableModule } from '@angular/material/table'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatDividerModule } from '@angular/material/divider'
import { MatExpansionModule } from '@angular/material/expansion'
import { TransactionRoutingModule } from './transaction-routing.module';
import { PipesModule } from '../../core/pipes/pipes.module';
import { ColorSumDirective } from '../../core/directives/color-sum.directive';



@NgModule({
  declarations: [
    HistoryComponent,
    DetailsComponent,
    ColorSumDirective,
  ],
  imports: [
    CommonModule,
    PipesModule,
    TransactionRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule,
    MatToolbarModule,
    MatDividerModule,
    MatExpansionModule
  ]
})
export class TransactionModule { }
