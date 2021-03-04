import { Component, OnInit } from '@angular/core';
import { FanmarvelService } from '../../../services/fanmarvel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-fanmarvel-update',
  templateUrl: './fanmarvel-update.component.html',
  styleUrls: ['./fanmarvel-update.component.css'],
})
export class FanmarvelUpdateComponent implements OnInit {
  selectedValueRole: string;
  unsubscriber = new Subject();
  fanmarvel = {
    id: 0,
    name: '',
    cpf: '',
    email: '',
    datanascimento: '',
  };
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  id = +this.route.snapshot.paramMap.get('id');

  constructor(
    private fanmarvelService: FanmarvelService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getByFanmarvel();
  }

  editFanmarvel(): void {
    this.loading = true;
    this.fanmarvelService
      .update(this.fanmarvel)
      .pipe()
      .subscribe(
        (data) => {
          this.router.navigate(['/fanmarvel']);
        },
        (error) => {
          this.error = error;
          this.loading = false;
        }
      );
  }

  getByFanmarvel(): void {
    this.loading = true;
    this.fanmarvelService
      .getById(this.id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((fanmarvel) => {
        this.loading = false;
        this.fanmarvel = fanmarvel;
      });
  }

  cancel(): void {
    this.router.navigate(['/fanmarvel']);
  }

  OnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
