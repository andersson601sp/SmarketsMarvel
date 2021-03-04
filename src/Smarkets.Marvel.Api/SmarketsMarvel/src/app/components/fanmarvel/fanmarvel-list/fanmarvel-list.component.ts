import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Fanmarvel } from '../../../models/fanmarvel';
import { FanmarvelService } from '../../../services';
import { PaginatedResult, Pagination } from '../../../models/Pagination';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-fanmarvel-list',
  templateUrl: './fanmarvel-list.component.html',
  styleUrls: ['./fanmarvel-list.component.css'],
})
export class FanmarvelListComponent implements OnInit {
  loading = false;
  fanmarvels: Fanmarvel[];
  displayedColumns = ['id', 'name', 'cpf', 'email', 'datanascimento'];
  pagination: Pagination;
  unsubscriber = new Subject();
  filtro = '';

  constructor(private router: Router, private fanmarvelService: FanmarvelService) {}

  ngOnInit(): void {
    this.pagination = { currentPage: 1, itemsPerPage: 10 } as Pagination;
    this.read();
  }

  read(): void {
    this.pagination.filtro = this.filtro;
    this.loading = true;
    this.fanmarvelService
      .getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((fanmarvels: PaginatedResult<Fanmarvel[]>) => {
        this.loading = false;
        this.fanmarvels = fanmarvels.result;
      });
  }

  navigateToFanmarvelsCreate(): void {
    this.router.navigate(['/fanmarvel/create']);
  }

  navigateToFanmarvelEdit(): void {
    this.router.navigate(['/fanmarvel/edit']);
  }

  OnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.read();
  }
}
