import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { PlayComponent } from './play/play.component';
import { OpenComponent } from './open/open.component';
import { CollectionComponent } from './collection/collection.component';
import { CardComponent } from './card/card.component';
import { RegisterComponent } from './register/register.component';
import { Card } from './card/card.component';
import { LoginHeaderComponent } from './login-header/login-header.component';
import { GameComponent } from './game/game.component';
import { DeckComponent } from './deck-maker/deck-maker.component';
import { DeckService } from './deck-maker/deck-service';
import { ResultService } from './result/result-service'; 
import { ResultComponent } from './result/result-component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    PlayComponent,
    OpenComponent,
    CollectionComponent,
    CardComponent,
    RegisterComponent,
    LoginHeaderComponent,
    GameComponent,
    DeckComponent,
    ResultComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'play', component: PlayComponent },
      { path: 'open', component: OpenComponent },
      { path: 'collection', component: CollectionComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'game', component: GameComponent },
      { path: 'deck', component: DeckComponent },
      { path: 'result', component: ResultComponent },
], { relativeLinkResolution: 'legacy' })
  ],
  providers: [Card, LoginComponent, LoginHeaderComponent, RegisterComponent, DeckService, ResultService],

  bootstrap: [AppComponent]
})
export class AppModule { }
