import { Component, OnInit, Input } from '@angular/core';
import { Portfolio } from '../portfolio.model';

@Component({
  selector: 'app-portfolio-list',
  templateUrl: './portfolio-list.component.html',
  styleUrls: ['./portfolio-list.component.css']
})
export class PortfolioListComponent implements OnInit {

  @Input()
  portfolioList: Array<Portfolio>;

  constructor() { }

  ngOnInit() {
  }

}
