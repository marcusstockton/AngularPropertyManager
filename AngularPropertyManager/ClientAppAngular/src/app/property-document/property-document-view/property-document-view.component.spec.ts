import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyDocumentViewComponent } from './property-document-view.component';

describe('PropertyDocumentViewComponent', () => {
  let component: PropertyDocumentViewComponent;
  let fixture: ComponentFixture<PropertyDocumentViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PropertyDocumentViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PropertyDocumentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
