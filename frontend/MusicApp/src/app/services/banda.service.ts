import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Banda } from '../model/banda';
import { Album } from '../model/album';

@Injectable({
  providedIn: 'root',
  
})
export class BandaService {

  private url = "https://localhost:7057/api/Banda"

  constructor(private httpClient: HttpClient) { }

  public getBanda() : Observable<Banda[]> {
     return this.httpClient.get<Banda[]>(this.url);
  }

  public getBandaPorId(id: string) : Observable<Banda> {
    return this.httpClient.get<Banda>(`${this.url}/${id}`);
  }

  public getAlbunsBanda(id: string) : Observable<Album[]> {
    return this.httpClient.get<Album[]>(`${this.url}/${id}/albums`);
  }
}
