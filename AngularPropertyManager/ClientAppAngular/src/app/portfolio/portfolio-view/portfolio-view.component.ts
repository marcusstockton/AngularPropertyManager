import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PortfolioService } from '../portfolio.service';
import { Portfolio } from '../portfolio.model';

@Component({
  selector: 'app-portfolio-view',
  templateUrl: './portfolio-view.component.html',
  styleUrls: ['./portfolio-view.component.css']
})
export class PortfolioViewComponent implements OnInit {
  private portfolioId: string;
  public portfolio: Portfolio;
  constructor(private route: ActivatedRoute, private portfolioService: PortfolioService) {
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.portfolioId = params.get("portfolioId")
      this.portfolioService.getPortfolioById(this.portfolioId).subscribe((data) => {
        this.portfolio = data;
      }, (error) => {
        console.log(error);
      });
    })
  }

}
