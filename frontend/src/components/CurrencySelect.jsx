import React, { useEffect, useState } from 'react';
import axios from "axios";
import Select from 'react-select';

const URL = "http://localhost:5231/api/Currencies"

export default function CurrencySelect({ setError, onSelectCurrency }) {
  const [currencies, setCurrencies] = useState([])

  async function getCurrencies() {
    try {
      const { data } = await axios.get(URL);
      setCurrencies(data
        .map(currency =>
          ({ value: currency.name, label: currency.name })
        ));
    } catch (error) {
      setError(error)
    }
  }

  useEffect(() => {
    getCurrencies()
  }, [])


  return (
    <>
      <Select
        className="basic-single"
        classNamePrefix="select"
        isSearchable={true}
        name="color"
        options={currencies}
        onChange={onSelectCurrency}
      />
    </>
  );
};