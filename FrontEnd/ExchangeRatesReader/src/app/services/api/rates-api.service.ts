import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { RateDto } from 'src/app/models/rate-dto';
import { LoadMaskService } from '../load-mask.service';
import { map, filter, tap, catchError } from 'rxjs/operators'


/**
 * Service for performing api operations concerning rates, contains also some base apiservice logics like error handling
 */
@Injectable({
  providedIn: 'root'
})
export class RatesApiService {

  constructor(private http: HttpClient, private loadMaskService: LoadMaskService) { }

  private readonly apiurl: string = 'api/rates';

  get(): Promise<RateDto[]> {
    return this.internalGet<RateDto[]>(this.apiurl).toPromise();
  }

  downloadLatest(): Promise<RateDto[]> {
    return this.internalPost<RateDto[]>(this.apiurl,null).toPromise();
  }

  private internalPost<T>(address: string, body: any): Observable<T> {
    this.loadMaskService.show();

    return this.http.post<T>(address, body).pipe(
      map((x)=> {
        this.loadMaskService.hide();
        return x;
      },
      this.catchErrorFn      
      ));
  }
  
  private internalGet<T>(address: string): Observable<any> {
    this.loadMaskService.show();

    return this.http.get<T>(this.apiurl).pipe(
        map((x)=> {
        this.loadMaskService.hide();
        return x;
      }),
      this.catchErrorFn  
    );
  }
  
  private catchErrorFn = catchError((err) => {
    this.loadMaskService.hide();
    console.log('error caught in service')
    console.error(err);
    alert(`Wystąpił błąd aplikacji: ${err.statusText}`);
    return throwError(err);    
  });
}
