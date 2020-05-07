import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Property } from './property.model';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  private propertyUrl = 'api/Properties';
  private base_url: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
  }

  public getPropertyById(id: string): Observable<Property> {
    return this.http.get<Property>(this.base_url + this.propertyUrl + "/" + id)
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
        )
      )
  }

  public updateProperty(id: string, property: FormData): Observable<Property> {
    return this.http.put<Property>(this.base_url + this.propertyUrl + "/" + id, property)
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
        )
      )
  }

  public createProperty(portfolioId: string, property: Property): Observable<Property> {
    return this.http.post<Property>(this.base_url + this.propertyUrl + '/' + portfolioId, property)
      .pipe(
        catchError((err) => {
          console.error(err);
          throw err;
        }
        )
      )
  }

}
