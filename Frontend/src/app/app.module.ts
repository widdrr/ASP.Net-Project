import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PricePipe } from './core/pipes/price.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GameComponent } from './pages/game/game.component';
import { AppRoutingModule } from './app-routing.module';
import { NavigationComponent } from './shared/navigation/navigation.component';
import { AuthModule } from './pages/auth/auth.module';

@NgModule({
  declarations: [
    AppComponent,
    PricePipe,
    GameComponent,
    NavigationComponent
  ],
  imports: [
    AuthModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
