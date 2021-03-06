import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;  

  constructor(private accountService: AccountService, private formBuilder: FormBuilder, private snackBar: MatSnackBar, private router: Router ) { }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      password: ['', Validators.required],
      robotsCrew: ['', Validators.required]
    })
  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(() => {
      this.router.navigate(['./planets-board']);
      this.snackBar.open('Successfully registered in!', 'Dismiss', { duration: 5000 });
    }, () => {
      this.snackBar.open('Something went wrong!', 'Dismiss', { duration: 5000 })
    });
  }
}