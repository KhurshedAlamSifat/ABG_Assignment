import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login(): void {
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        if (response.token && response.token !== 'Invalid user') {
          localStorage.setItem('token', response.token);
          this.router.navigate(['/products']);
        } else {
          this.errorMessage = 'Invalid credentials';
        }
      },
      (error) => {
        this.errorMessage = 'An error occurred while logging in';
        console.error('Login error:', error);
      }
    );
  }
}
