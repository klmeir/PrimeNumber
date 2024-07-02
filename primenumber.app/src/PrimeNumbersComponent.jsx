import React, { useState } from 'react';
import { Button, Form, FormGroup, Input, ListGroup, ListGroupItem } from 'reactstrap';

import { getPrimeNumbers } from './apiService';

const PrimeNumbersComponent = () => {
  const [initialNumber, setInitialNumber] = useState(0);
  const [limitNumber, setLimitNumber] = useState(0);
  const [user, setUser] = useState('');
  const [primeNumbers, setPrimeNumbers] = useState([]);

  const handleFormSubmit = async (event) => {
    event.preventDefault();
    try {
      const primes = await getPrimeNumbers(initialNumber, limitNumber, user);
      setPrimeNumbers(primes);
    } catch (error) {
      console.error('Error fetching prime numbers:', error);      
    }
  };

  return (
    <div className="container mt-5">
      <h2>Obtener Números Primos</h2>
      <Form onSubmit={handleFormSubmit}>
        <FormGroup>
          <label htmlFor="initialNumber">Número Inicial:</label>
          <Input
            type="number"
            id="initialNumber"
            value={initialNumber}
            onChange={(e) => setInitialNumber(e.target.value)}
            required
          />
        </FormGroup>
        <FormGroup>
          <label htmlFor="limitNumber">Números a obtener:</label>
          <Input
            type="number"
            id="limitNumber"
            value={limitNumber}
            onChange={(e) => setLimitNumber(e.target.value)}
            required
          />
        </FormGroup>
        <FormGroup>
          <label htmlFor="user">Usuario:</label>
          <Input
            type="text"
            id="user"
            value={user}
            onChange={(e) => setUser(e.target.value)}
            required
          />
        </FormGroup>
        <Button type="submit" color="primary">
          Obtener Números Primos
        </Button>
      </Form>

      <h3 className="mt-4">Números Primos:</h3>
      <ListGroup>
        {primeNumbers.map((number, index) => (
          <ListGroupItem key={index}>{number}</ListGroupItem>
        ))}
      </ListGroup>
    </div>
  );
};

export default PrimeNumbersComponent;
