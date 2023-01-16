import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { GameComponent } from './pages/game/game.component';
import { LoginComponent } from './pages/auth/login/login.component';

const routes: Routes = [
  {
    path: 'browse',
    component: GameComponent
  },
  {
    path: 'login',
    component: LoginComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }