import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { PortfolioService } from '../portfolio.service';
import { Portfolio } from '../portfolio.model';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-portfolio-form',
  templateUrl: './portfolio-form.component.html',
  styleUrls: ['./portfolio-form.component.css']
})
export class PortfolioFormComponent implements OnInit {
  public portfolioId: string;

  constructor(
    private route: ActivatedRoute,
    private portfolioService: PortfolioService,
    private _location: Location,
    private router: Router,
    private toastr: ToastrService) {

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
    if (this.portfolioId) {
      this.portfolioService.updatePortfolio(this.portfolioId, this.portfolioForm.value).subscribe((data) => {
        this.toastr.success("Portfolio updated", "Success");
        this.router.navigate(['/portfolios', { portfolioId: this.portfolioId }]);
      }, (error) => {
        this.toastr.error(error.statusText, "Error");
        console.error(error);
      })
    } else {
      // Post
      this.portfolioService.createPortfolio(this.portfolioForm.value).subscribe((data) => {
        this.toastr.success("Portfolio created", "Success");
        this.router.navigate(['/portfolios', { portfolioId: this.portfolioId }]);
      }, (error) => {
        this.toastr.error(error, "Error");
        console.error(error);
      })
    }

  }

  backClicked() {
    this._location.back();
  }
}
