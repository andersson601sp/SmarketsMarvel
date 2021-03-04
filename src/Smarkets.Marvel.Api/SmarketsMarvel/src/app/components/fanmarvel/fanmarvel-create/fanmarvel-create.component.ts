import { Component, OnInit } from '@angular/core';
import { FanmarvelService } from '../../../services/fanmarvel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-fanmarvel-create',
  templateUrl: './fanmarvel-create.component.html',
  styleUrls: ['./fanmarvel-create.component.css']
})
export class FanmarvelCreateComponent implements OnInit {
  selectedValueRole: string;

  fanmarvel = {
    id: 0,
    name: '',
    cpf: '',
    email: '',
    datanascimento: ''
  };

  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(private fanmarvelService: FanmarvelService,  private router: Router) { }

  ngOnInit(): void {
  }

  createFanmarvel(): void {
    this.loading = true;
    this.fanmarvelService.create(this.fanmarvel)
        .pipe()
        .subscribe(
            data => {
            this.router.navigate(['/fanmarvel']);
            },
            error => {
                this.error = error;
                this.loading = false;
            });
  }

  cancel(): void {
    this.router.navigate(['/fanmarvel']);
  }

}
