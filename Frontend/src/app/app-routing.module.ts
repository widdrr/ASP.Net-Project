import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { GameComponent } from './pages/browse/game/game.component';

const routes: Routes = [
  {
    path: 'browse',
    component: GameComponent,
    canActivate: [AuthGuard]
    
  },
  {
    path: 'auth',
    loadChildren: () => import('./pages/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'transaction',
    loadChildren: () => import('./pages/transaction/transaction.module').then(m => m.TransactionModule),
    canActivate: [AuthGuard]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
