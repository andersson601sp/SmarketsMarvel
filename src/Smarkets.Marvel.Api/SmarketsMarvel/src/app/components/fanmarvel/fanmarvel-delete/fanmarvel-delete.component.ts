import { Component, OnInit } from '@angular/core';
import { FanmarvelService } from '../../../services/fanmarvel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-fanmarvel-delete',
  templateUrl: './fanmarvel-delete.component.html',
  styleUrls: ['./fanmarvel-delete.component.css'],
})
export class FanmarvelDeleteComponent implements OnInit {
  loginForm: FormGroup;
  unsubscriber = new Subject();
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  id = +this.route.snapshot.paramMap.get('id');

  fanmarvel = {
    id: 0,
    name: '',
    cpf: '',
    email: '',
    datanascimento: ''
  };

  constructor(
    private fanmarvelService: FanmarvelService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getByFanmarvel();
  }

  getByFanmarvel(): void {
    this.loading = true;
    this.fanmarvelService
      .getById(this.id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe(
        (fanmarvel) => {
          this.loading = false;
          this.fanmarvel = fanmarvel;
        },
        (error) => {
          this.error = error;
          this.loading = false;
        }
      );
  }

  confirmaexclusao(): void {
    this.deleteFanmarvel();
    this.router.navigate(['/fanmarvel']);
  }

  deleteFanmarvel(): void {
    this.loading = true;
    return this.fanmarvelService
      .delete(this.id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe(() => {
        },
        () => {
          this.error = 'Erro ao tentar excluir usuário';
          this.loading = false;
        }
      );
  }

  cancel(): void {
    this.router.navigate(['/fanmarvel']);
  }

  OnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
