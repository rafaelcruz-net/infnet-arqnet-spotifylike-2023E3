import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { UsuarioService } from '../services/usuario.service';
import { Usuario } from '../model/usuario';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule, CommonModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Usuario;
  token!: any

  constructor(private usuarioService: UsuarioService, private router: Router) {

  }

  public login() {
    if (this.email.invalid || this.senha.invalid) {
      return;
    }

    let emailValue = this.email.getRawValue() as string;
    let senhaValue = this.senha.getRawValue() as string;

    this.usuarioService.autenticar(emailValue, senhaValue).subscribe(
      {
        next: (response) => {
          this.token = jwtDecode(response.access_token);
          sessionStorage.setItem("user_session", JSON.stringify(this.token));
          sessionStorage.setItem("access_token", response.access_token);
          this.router.navigate(["/home"]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });


  }


}
