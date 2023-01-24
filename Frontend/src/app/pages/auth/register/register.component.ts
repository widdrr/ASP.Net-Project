import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../../core/services/user.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  public registerForm = this.formBuilder.group({
    username: ['', Validators.required],
    email:    ['',Validators.email],
    password: ['', Validators.required]
  });

  constructor(private readonly formBuilder: FormBuilder,
    private readonly router: Router,
    private readonly authService: UserService) { }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.router.navigate(['/auth/login'])
        .then(() => window.location.reload());
    })
  }
}
