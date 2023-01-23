import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from './pages/auth/auth.module';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { GameComponent } from './pages/game/game.component';
import { NavigationComponent } from './shared/navigation/navigation.component';

import { PricePipe } from './core/pipes/price.pipe';

import { TokenInterceptor } from './core/interceptors/token.interceptor';

import { OwnCheckDirective } from './core/directives/own-check.directive';

@NgModule({
  declarations: [
    AppComponent,
    PricePipe,
    GameComponent,
    NavigationComponent,
    OwnCheckDirective
  ],
  imports: [
    AuthModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
