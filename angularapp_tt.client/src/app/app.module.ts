import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SavedComponent } from './components/pages/saved/saved.component';
import { HomeComponent } from './components/pages/home/home.component';
import { AuthModule } from './components/layout/Auth/auth.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { environment } from './enviroment';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule } from '@angular/forms';
import { ACCESS_TOKEN } from '../service/Auth.service';
import { HeaderComponent } from './components/layout/header/header.component';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN);
}

@NgModule({
  declarations: [
    AppComponent,
    SavedComponent,
    HomeComponent,
    HeaderComponent

  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    AuthModule,
    FormsModule,
    //BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: environment.apiUrl,
      },
    }),


  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
