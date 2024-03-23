import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = "https://localhost:7057/api/User"
  
  constructor(private http: HttpClient) { }

  public autenticar(email:String, senha: String) : Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/login`, {
      email:email,
      senha:senha
    });
  }

}
