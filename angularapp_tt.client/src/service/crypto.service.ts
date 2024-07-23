import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { СryptoRate } from '../models/User/СryptoRate';
import { Observable } from 'rxjs';
import { environment } from '../app/enviroment';

@Injectable({
  providedIn: 'root'
})
export class CryptoService {

  constructor(private http: HttpClient) { }

  getRates(): Observable<СryptoRate[]> {

    return this.http.get<СryptoRate[]>(`/crypto`);

  }

  saveRate(rate: СryptoRate): Observable<СryptoRate> {
    return this.http.post<СryptoRate>(`/crypto/Save`, rate);
  }
}

