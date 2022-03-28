import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http'
import { AppComponent } from './app.component';
import { RatesApiService} from './services/api/rates-api.service';
import { RatesTableComponent } from './rates-table/rates-table.component';
import '@angular/common/locales/global/pl';
import { LoadMaskComponent } from './load-mask/load-mask.component'
import { LoadMaskService } from './services/load-mask.service';

@NgModule({
  declarations: [
    AppComponent,
    RatesTableComponent,
    LoadMaskComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
      RatesApiService,
      LoadMaskService,
      {provide: LOCALE_ID, useValue: 'pl' }    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
