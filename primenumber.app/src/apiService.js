const API_URL = 'http://localhost:5017/primenumbers/generate';

export const getPrimeNumbers = async (initialNumber, primeNumbers, user) => {
  const response = await fetch(API_URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      initialNumber: initialNumber,
      primeNumbers: primeNumbers,
      user: user,
    }),
  });

  if (!response.ok) {
    throw new Error(`HTTP error! Status: ${response.status}`);
  }

  const data = await response.json();
  return data.primeNumbers;
};
