import { TestBed } from '@angular/core/testing';

import { Cnab } from './cnab';

describe('Cnab', () => {
  let service: Cnab;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Cnab);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
