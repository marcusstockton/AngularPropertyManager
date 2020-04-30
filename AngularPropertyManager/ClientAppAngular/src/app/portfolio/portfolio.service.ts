import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Portfolio } from './portfolio.model';
import { Observable } from 'rxjs';
import { catchError, tap} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PortfolioService {

  private portfolioUrl = 'api/Portfolios';
  private base_url: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
  }

  public getPortfolios(): Observable<Portfolio[]> {
    return this.http.get<Portfolio[]>(this.base_url + this.portfolioUrl)
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
        )
      )
  }

  public getPortfolioById(id: string): Observable<Portfolio> {
    const params = new HttpParams().set('id', id);
    return this.http.get<Portfolio>(this.base_url + this.portfolioUrl + "/" + id)
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
        )
      )
  }


}
