import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RatesTableComponent } from './rates-table/rates-table.component';

const routes: Routes = [
  { path: '', component: RatesTableComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
