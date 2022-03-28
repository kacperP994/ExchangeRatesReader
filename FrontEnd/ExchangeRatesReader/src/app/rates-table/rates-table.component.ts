import { Component, OnInit } from '@angular/core';
import { RatesApiService } from '../services/api/rates-api.service';
import { RateDto } from '../models/rate-dto';

/**
 * Component for presentation of data related do currencies' rates
 */
@Component({
  selector: 'app-rates-table',
  templateUrl: './rates-table.component.html',
  styleUrls: ['./rates-table.component.less']
})
export class RatesTableComponent implements OnInit {

  constructor(private ratesApiService: RatesApiService) { }

  
  public data: RateDto[] = [];

  ngOnInit(): void {
    this.ratesApiService.get()
      .then((res)=> {
        this.data = res;
      });  
  }

  onLoadRates() {
    this.ratesApiService.downloadLatest()
      .then((res)=> {
        this.data = res;
      });
  }
}
