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

    return this.http.get<СryptoRate[]>(`${environment.apiUrl[0]}/api/Crypto/`);

  }

  saveRate(rate: СryptoRate): Observable<СryptoRate> {
    // Предполагается, что у вас есть эндпоинт на сервере для сохранения криптовалюты
    return this.http.post<СryptoRate>(`${environment.apiUrl[0]}/api/Crypto/Save`, rate);
  }
}
