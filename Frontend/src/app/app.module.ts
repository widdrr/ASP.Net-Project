import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from './pages/auth/auth.module';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSidenavModule } from '@angular/material/sidenav'
import { MatButtonModule } from '@angular/material/button'

import { AppComponent } from './app.component';
import { NavigationComponent } from './shared/navigation/navigation.component';

import { TokenInterceptor } from './core/interceptors/token.interceptor';

import { BrowseModule } from './pages/browse/browse.module';
import { TransactionModule } from './pages/transaction/transaction.module';


@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
  ],
  imports: [
    AuthModule,
    BrowseModule,
    TransactionModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatButtonModule,

  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
