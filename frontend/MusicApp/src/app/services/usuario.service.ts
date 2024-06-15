import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "https://localhost:7081/connect/token"
  
  constructor(private http: HttpClient) { }

  public autenticar(email:string, senha: string) : Observable<any> {

    let body = new URLSearchParams();
    body.set("username", email);
    body.set("password", senha);
    body.set("client_id", "client-angular-spotify");
    body.set("client_secret", "SpotifyLikeSecret");
    body.set("grant_type", "password");
    body.set("scope", "SpotifyLikeScope");

    let options = {
      headers: new HttpHeaders().set("Content-Type", "application/x-www-form-urlencoded")
    }
    
    return this.http.post(`${this.url}`, body.toString(), options);
  }

}
