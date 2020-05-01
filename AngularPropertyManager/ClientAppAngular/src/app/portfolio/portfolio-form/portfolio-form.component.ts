import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { PortfolioService } from '../portfolio.service';
import { Portfolio } from '../portfolio.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-portfolio-form',
  templateUrl: './portfolio-form.component.html',
  styleUrls: ['./portfolio-form.component.css']
})
export class PortfolioFormComponent implements OnInit {
  private portfolioId: string;
  constructor(
    private route: ActivatedRoute,
    private portfolioService: PortfolioService,
    private _location: Location,
    private router: Router) {
    
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.portfolioId = params.get("portfolioId")
      if (this.portfolioId.length > 0) {
        this.portfolioService.getPortfolioById(this.portfolioId).subscribe((data: Portfolio) => {
          this.portfolioForm.setValue(data);
        }, (error) => {
          console.error(error)
        });
      }
    })
  }

  portfolioForm = new FormGroup({
    id: new FormControl(''),
    name: new FormControl(''),
    createdDateTime: new FormControl(''),
    updatedDateTime: new FormControl(''),
    owner: new FormControl(''),
    properties: new FormControl('')
  });

  onSubmit() {
    console.warn(this.portfolioForm.value);
    this.portfolioService.updatePortfolio(this.portfolioId, this.portfolioForm.value).subscribe((data) => {
      this.router.navigate(['/portfolios', { portfolioId: this.portfolioId }]);
    }, (error) => {
        console.error(error);
    })
  }

  backClicked() {
    this._location.back();
  }
}
