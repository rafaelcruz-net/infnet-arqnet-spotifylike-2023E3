import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Banda } from '../model/banda';

@Injectable({
  providedIn: 'root',
  
})
export class BandaService {

  private url = "https://localhost:7057/api/Banda"

  constructor(private httpClient: HttpClient) { }

  public getBanda() : Observable<Banda[]> {
     return this.httpClient.get<Banda[]>(this.url);
  }
}
