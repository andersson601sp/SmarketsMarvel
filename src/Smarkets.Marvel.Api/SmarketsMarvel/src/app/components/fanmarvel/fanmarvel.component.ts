import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fanmarvel',
  templateUrl: './fanmarvel.component.html',
  styleUrls: ['./fanmarvel.component.css']
})
export class FanmarvelComponent implements OnInit {
  constructor(private router: Router) { }

  ngOnInit(): void {

}

  navigateToFanmarvelCreate(): void {
    this.router.navigate(['/fanmarvel/create']);
  }
}
