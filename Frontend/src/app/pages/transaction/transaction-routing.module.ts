import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HistoryComponent } from './history/history.component';
import { DetailsComponent } from './details/details.component';

const routes: Routes = [
  {
    path: "history",
    component: HistoryComponent
  },
  {
    path: "details/:trId",
    component: DetailsComponent
  },
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
    ]
})
export class TransactionRoutingModule { }

function RoutingModule(forChild: any): any[] | import("@angular/core").Type<any> | import("@angular/core").ModuleWithProviders<{}> {
    throw new Error('Function not implemented.');
}
