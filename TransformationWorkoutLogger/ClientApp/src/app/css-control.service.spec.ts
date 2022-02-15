import { TestBed } from '@angular/core/testing';

import { CssControlService } from './css-control.service';

describe('CssControlService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CssControlService = TestBed.get(CssControlService);
    expect(service).toBeTruthy();
  });
});
