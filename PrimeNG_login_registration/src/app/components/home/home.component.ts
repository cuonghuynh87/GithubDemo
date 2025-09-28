import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { User } from '../../interfaces/auth';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  userName = '';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    if (sessionStorage.getItem('email')) {
      this.userName = sessionStorage.getItem('name') || '';
    } else {
      this.router.navigateByUrl('/');
    }
  }

  logout() {
    sessionStorage.clear();
    this.router.navigate(['login']);
  }
}
