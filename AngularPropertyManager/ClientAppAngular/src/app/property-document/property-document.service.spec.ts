import { TestBed } from '@angular/core/testing';

import { PropertyDocumentService } from './property-document.service';

describe('PropertyDocumentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropertyDocumentService = TestBed.get(PropertyDocumentService);
    expect(service).toBeTruthy();
  });
});
